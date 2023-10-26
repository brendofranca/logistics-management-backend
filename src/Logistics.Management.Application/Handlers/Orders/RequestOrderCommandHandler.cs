using Logistics.Management.Application.Commands.Orders;
using Logistics.Management.Application.Notifications;
using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Enums;
using Logistics.Management.Data.Repositories.Items;
using Logistics.Management.Data.Repositories.Orders;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Logistics.Management.Application.Handlers.Orders
{
    public sealed class RequestOrderCommandHandler : IRequestHandler<RequestOrderCommand, bool>
    {
        private readonly ILogger<RequestOrderCommandHandler> _logger;
        private readonly IDomainNotification _domainNotification;
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;

        public RequestOrderCommandHandler(ILogger<RequestOrderCommandHandler> logger
                                       , IDomainNotification domainNotification
                                       , IOrderRepository orderRepository
                                       , IItemRepository itemRepository)
        {
            _logger = logger;
            _domainNotification = domainNotification;
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(RequestOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order(request.Id, request.Description);

                foreach (var (ItemId, Quantity) in request.Items)
                {
                    var itemDb = await _itemRepository.FindByIdAsync(ItemId, cancellationToken);

                    if (itemDb != null)
                    {
                        order.OrderItems.Add(new OrderItem(Guid.NewGuid(), Quantity, order.Id, ItemId));
                    }
                    else
                    {
                        _domainNotification.AddNotification($"ItemId - {ItemId} not found.");
                    }
                }

                if (_domainNotification.HasNotifications())
                {
                    return false;
                }

                var orderStatus = new OrderStatus(Guid.NewGuid(), (int)Status.REQUESTED, order.Id);
                order.OrderStatuses.Add(orderStatus);

                await _orderRepository.InsertAsync(order, cancellationToken);
                await _orderRepository.UnitOfWork.CommitAsync(cancellationToken);

                order.OrderStatusId = orderStatus.Id;
                await _orderRepository.UpdateAsync(order, cancellationToken);
                await _orderRepository.UnitOfWork.CommitAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to request order {message}", ex.Message);

                return false;
            }
        }
    }
}