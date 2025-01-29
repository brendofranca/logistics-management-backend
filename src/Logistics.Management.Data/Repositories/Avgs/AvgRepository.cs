using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Management.Data.Repositories.Avgs
{
    public class AvgRepository : RepositoryGeneric<AutomatedGuidedVehicle>, IAvgRepository
    {
        public AvgRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<AutomatedGuidedVehicle?> FindByIdAsync(Guid id, CancellationToken cancellationToken) =>
             await Context.GetDbSet<AutomatedGuidedVehicle>()
                          .AsNoTracking()
                          .Include(a => a.Location)
                          .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }
}