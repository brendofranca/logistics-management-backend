using Logistics.Management.Application.Commands.Orders;
using Logistics.Management.Application.Notifications;
using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Enums;
using Logistics.Management.Data.Repositories.Orders;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Logistics.Management.Application.Handlers.Orders
{
    public sealed class ReceiveOrderCommandHandler : IRequestHandler<ReceiveOrderCommand, bool>
    {
        private readonly ILogger<ReceiveOrderCommandHandler> _logger;
        private readonly IDomainNotification _domainNotification;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;

        public ReceiveOrderCommandHandler(ILogger<ReceiveOrderCommandHandler> logger
                                        , IDomainNotification domainNotification
                                        , IOrderRepository orderRepository
                                        , IOrderStatusRepository orderStatusRepository)
        {
            _logger = logger;
            _domainNotification = domainNotification;
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<bool> Handle(ReceiveOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);

                if (order == null)
                {
                    _domainNotification.AddNotification($"OrderId - {request.Id} not found.");
                }

                if (order?.OrderStatus?.StatusId == (int)Status.REQUESTED)
                {
                    _domainNotification.AddNotification($"Order already requested.");
                }

                if (order?.OrderStatus?.StatusId == (int)Status.COLLECTION)
                {
                    _domainNotification.AddNotification($"Order already collection.");
                }

                if (order?.OrderStatus?.StatusId == (int)Status.RECEIVED)
                {
                    _domainNotification.AddNotification($"Order already received.");
                }

                if (_domainNotification.HasNotifications())
                {
                    return false;
                }

                if (order != null)
                {
                    var orderStatus = new OrderStatus(Guid.NewGuid(), (int)Status.RECEIVED, order.Id);

                    await _orderStatusRepository.InsertAsync(orderStatus, cancellationToken);

                    await _orderStatusRepository.UpdateAsync(order.OrderStatus, cancellationToken);

                    order.OrderStatusId = orderStatus.Id;

                    await _orderRepository.UpdateAsync(order, cancellationToken);

                    await _orderRepository.UnitOfWork.CommitAsync(cancellationToken);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to receive order {message}", ex.Message);

                return false;
            }
        }
    }
}