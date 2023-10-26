using Logistics.Management.Application.Commands.Orders;
using Logistics.Management.Application.Notifications;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Enums;
using Logistics.Management.Data.Repositories.Avgs;
using Logistics.Management.Data.Repositories.Orders;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Logistics.Management.Application.Handlers.Orders
{
    public sealed class CollectOrderCommandHandler : IRequestHandler<CollectOrderCommand, CollectOrderResponse?>
    {
        private readonly ILogger<CollectOrderCommandHandler> _logger;
        private readonly IDomainNotification _domainNotification;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IAvgRepository _avgRepository;

        public CollectOrderCommandHandler(ILogger<CollectOrderCommandHandler> logger
                                        , IDomainNotification domainNotification
                                        , IOrderRepository orderRepository
                                        , IOrderStatusRepository orderStatusRepository
                                        , IAvgRepository avgRepository)
        {
            _logger = logger;
            _domainNotification = domainNotification;
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
            _avgRepository = avgRepository;
        }

        public async Task<CollectOrderResponse?> Handle(CollectOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);

                if (order == null)
                {
                    _domainNotification.AddNotification($"OrderId - {request.Id} not found.");
                }

                if (order?.OrderStatus?.StatusId == (int)Status.COLLECTION)
                {
                    _domainNotification.AddNotification($"Order already collected.");
                }

                if (order?.OrderStatus?.StatusId == (int)Status.SENT)
                {
                    _domainNotification.AddNotification($"Order already sent.");
                }

                if (order?.OrderStatus?.StatusId == (int)Status.RECEIVED)
                {
                    _domainNotification.AddNotification($"Order already received.");
                }

                var avg = await _avgRepository.FindByIdAsync(request.AvgId, cancellationToken);

                if (avg == null)
                {
                    _domainNotification.AddNotification($"AvgId - {request.AvgId} not found.");
                }

                if (_domainNotification.HasNotifications())
                {
                    return null;
                }

                if (order != null && avg != null)
                {
                    var fatestRoute = CalculateFastestRoute(ref order, ref avg);

                    var orderStatus = new OrderStatus(Guid.NewGuid(), (int)Status.COLLECTION, order.Id);

                    await _orderStatusRepository.InsertAsync(orderStatus, cancellationToken);

                    await _orderStatusRepository.UpdateAsync(order.OrderStatus, cancellationToken);

                    order.OrderStatusId = orderStatus.Id;

                    await _orderRepository.UpdateAsync(order, cancellationToken);

                    await _orderRepository.UnitOfWork.CommitAsync(cancellationToken);

                    return new CollectOrderResponse() { FatestRoute = fatestRoute };
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to collect order {message}", ex.Message);

                return null;
            }
        }

        private static string CalculateFastestRoute(ref Order order, ref AutomatedGuidedVehicle avg)
        {
            var itemPositions = order.OrderItems.Select(p => p?.Item?.Location).ToList();
            itemPositions.Insert(0, avg.Location);
            var numLocations = itemPositions.Count;

            var visitOrder = new int[numLocations];

            for (var i = 0; i < numLocations; i++)
            {
                visitOrder[i] = -1;
            }

            var currentLocation = 0;
            visitOrder[0] = 0;

            decimal shortestDistance = 0;

            for (var i = 1; i < numLocations; i++)
            {
                var minDistance = decimal.MaxValue;
                var nearestLocation = -1;

                for (var j = 0; j < numLocations; j++)
                {
                    if (visitOrder[j] == -1)
                    {
                        var distance = CalculateDistance(itemPositions[currentLocation], itemPositions[j]);

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestLocation = j;
                        }
                    }
                }

                visitOrder[i] = nearestLocation;
                shortestDistance += minDistance;
                currentLocation = nearestLocation;
            }

            var routeString = string.Join(" -> ", visitOrder.Select(index => $"Location {index}"));

            return $"Fastest route: {routeString}, Total Distance: {shortestDistance}";
        }

        private static decimal CalculateDistance(Location location1, Location location2)
        {
            var x1 = location1.LocationX;
            var y1 = location1.LocationY;
            var x2 = location2.LocationX;
            var y2 = location2.LocationY;

            return (decimal)Math.Sqrt((double)(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1))));
        }
    }
}