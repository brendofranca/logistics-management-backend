using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Application.Services.Goods
{
    public interface IGoodService
    {
        Task<GoodResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<GoodResponse>> GetAllAsync(CancellationToken cancellationToken);

        // Task<bool> RegisterAsync(Good Good, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}