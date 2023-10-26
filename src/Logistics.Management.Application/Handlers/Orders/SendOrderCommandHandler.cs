using Logistics.Management.Application.Commands.Orders;
using Logistics.Management.Application.Notifications;
using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Enums;
using Logistics.Management.Data.Repositories.Orders;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Logistics.Management.Application.Handlers.Orders
{
    public sealed class SendOrderCommandHandler : IRequestHandler<SendOrderCommand, bool>
    {
        private readonly ILogger<SendOrderCommandHandler> _logger;
        private readonly IDomainNotification _domainNotification;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;

        public SendOrderCommandHandler(ILogger<SendOrderCommandHandler> logger
                                     , IDomainNotification domainNotification
                                     , IOrderRepository orderRepository
                                     , IOrderStatusRepository orderStatusRepository)
        {
            _logger = logger;
            _domainNotification = domainNotification;
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<bool> Handle(SendOrderCommand request, CancellationToken cancellationToken)
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

                if (order?.OrderStatus?.StatusId == (int)Status.SENT)
                {
                    _domainNotification.AddNotification($"Order already sent.");
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
                    var orderStatus = new OrderStatus(Guid.NewGuid(), (int)Status.SENT, order.Id);

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
                _logger.LogError("Error to send order {message}", ex.Message);

                return false;
            }
        }
    }
}