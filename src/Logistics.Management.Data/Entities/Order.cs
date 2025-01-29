using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class Order : Entity
    {
        public string Description { get; set; } = string.Empty;
        public Guid? OrderStatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; } = new List<OrderStatus>();

        // EF
        protected Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderStatuses = new HashSet<OrderStatus>();
        }

        public Order(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}