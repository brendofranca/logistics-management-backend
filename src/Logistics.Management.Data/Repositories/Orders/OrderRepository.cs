using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Management.Data.Repositories.Orders
{
    public class OrderRepository : RepositoryGeneric<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Order>> FindAllAsync(CancellationToken cancellationToken) =>
           await Context.GetDbSet<Order>()
                        .AsNoTracking()
                        .Include(o => o.OrderStatus)
                        .ToListAsync(cancellationToken);

        public override async Task<Order?> FindByIdAsync(Guid id, CancellationToken cancellationToken) =>
           await Context.GetDbSet<Order>()
                        .AsNoTracking()
                        .Include(o => o.OrderStatus)
                        .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Item)
                        .ThenInclude(i => i.Location)
                        .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
}