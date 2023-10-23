using Logistics.Management.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Logistics.Management.Data.Context.Abstractions
{
    public interface IContext : IUnitOfWork
    {
        DbSet<T> GetDbSet<T>() where T : class;

        DbConnection GetDbConnection();
    }
}