using System.Data.Common;

namespace Logistics.Management.Data.Repositories.Abstractions
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }

        DbConnection GetDbConnection();
    }
}