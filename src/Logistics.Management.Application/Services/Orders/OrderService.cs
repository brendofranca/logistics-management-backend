using AutoMapper;
using Logistics.Management.Application.Requests;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Entities;
using Logistics.Management.Data.Repositories.Items;
using Logistics.Management.Data.Repositories.Orders;

namespace Logistics.Management.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IItemRepository _itemRepository;

        public OrderService(IMapper mapper
                            , IOrderRepository orderRepository
                            , IOrderStatusRepository orderStatusRepository
                            , IOrderItemRepository orderItemRepository
                            , IItemRepository itemRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
            _orderItemRepository = orderItemRepository;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.FindAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<OrderResponse>>(orders);
        }

        public async Task<OrderResponse> GetOrderById(Guid id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(id, cancellationToken);
            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<bool> InsertOrder(OrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order(request.Id, request.Description);

                await _orderRepository.InsertAsync(order, cancellationToken);

                await _orderRepository.UnitOfWork.CommitAsync(cancellationToken);

                var orderStatus = new OrderStatus(request.Id, 1, order.Id);

                await _orderStatusRepository.InsertAsync(orderStatus, cancellationToken);

                await _orderStatusRepository.UnitOfWork.CommitAsync(cancellationToken);

                order.OrderStatusId = orderStatus.Id;

                await _orderRepository.UpdateAsync(order, cancellationToken);

                await _orderRepository.UnitOfWork.CommitAsync(cancellationToken);

                foreach (var item in request.Items)
                {
                    var itemDb = await _itemRepository.FindByIdAsync(item.ItemId, cancellationToken);

                    if (itemDb != null)
                    {
                        await _orderItemRepository.InsertAsync(new OrderItem(request.Id, item.Quantity, order.Id, itemDb.Id), cancellationToken);
                    }
                }

                await _orderItemRepository.UnitOfWork.CommitAsync(cancellationToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> ProcessOrder(ProcessOrderRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}