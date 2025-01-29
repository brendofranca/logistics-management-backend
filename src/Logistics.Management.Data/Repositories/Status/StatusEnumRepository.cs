using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Data.Repositories.Status
{
    public class StatusEnumRepository : RepositoryGeneric<StatusEnum>, IStatusEnumRepository
    {
        public StatusEnumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}