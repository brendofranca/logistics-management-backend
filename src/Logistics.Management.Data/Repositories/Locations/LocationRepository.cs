using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Data.Repositories.Locations
{
    public class LocationRepository : RepositoryGeneric<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}