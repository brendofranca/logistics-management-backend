using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Data.Repositories.Avgs
{
    public class AvgRepository : RepositoryGeneric<AutomatedGuidedVehicle>, IAvgRepository
    {
        public AvgRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}