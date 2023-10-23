using Microsoft.EntityFrameworkCore.Storage;

namespace Logistics.Management.Data.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}