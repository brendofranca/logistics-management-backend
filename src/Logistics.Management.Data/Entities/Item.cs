using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class Item : Entity
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }

        public Guid? LocationId { get; set; }

        public virtual Location? Location { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        // EF
        protected Item() => OrderItems = new HashSet<OrderItem>();

        public Item(Guid id, string name, int quantity, Guid locationId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            LocationId = locationId;
        }
    }
}