using AutoMapper;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Enums;
using Logistics.Management.Data.Repositories.Orders;

namespace Logistics.Management.Application.Queries.Orders
{
    public class OrderQuery : IOrderQuery
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderQuery(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<RequestOrderResponse>> GetAllOrders(Status status, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.FindAllAsync(cancellationToken);

            if ((int)status > 0)
            {
                orders = orders.Where(o => o.OrderStatus?.StatusId == (int)status).ToList();
            }

            return _mapper.Map<IEnumerable<RequestOrderResponse>>(orders);
        }

        public Task<IEnumerable<RequestOrderResponse>> GetOrderById(Status status, CancellationToken cancellationToken) => throw new NotImplementedException();

        public async Task<RequestOrderResponse> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(id, cancellationToken);

            return _mapper.Map<RequestOrderResponse>(order);
        }
    }
}