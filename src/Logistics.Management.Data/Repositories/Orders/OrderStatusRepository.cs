using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Data.Repositories.Orders
{
    public class OrderStatusRepository : RepositoryGeneric<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}