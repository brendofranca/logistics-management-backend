using Logistics.Management.Data.Context;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Data.Repositories.Items
{
    public class ItemRepository : RepositoryGeneric<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}