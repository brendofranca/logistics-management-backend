using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Enums;

namespace Logistics.Management.Application.Queries.Orders
{
    public interface IOrderQuery
    {
        Task<IEnumerable<RequestOrderResponse>> GetAllOrders(Status status, CancellationToken cancellationToken);

        Task<IEnumerable<RequestOrderResponse>> GetOrderById(Status status, CancellationToken cancellationToken);

        Task<RequestOrderResponse> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}