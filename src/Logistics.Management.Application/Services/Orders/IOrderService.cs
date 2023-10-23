using Logistics.Management.Application.Requests;
using Logistics.Management.Application.Responses;

namespace Logistics.Management.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllOrders(CancellationToken cancellationToken);

        Task<OrderResponse> GetOrderById(Guid id, CancellationToken cancellationToken);

        Task<bool> InsertOrder(OrderRequest request, CancellationToken cancellationToken);

        Task<bool> ProcessOrder(ProcessOrderRequest request, CancellationToken cancellationToken);
    }
}