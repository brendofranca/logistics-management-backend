using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public partial class OrderStatus : Entity
    {
        public int? StatusId { get; set; }
        public Guid? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual StatusEnum? Status { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        // EF
        protected OrderStatus() => Orders = new HashSet<Order>();

        public OrderStatus(Guid id, int statusId, Guid orderId)
        {
            Id = id;
            OrderId = orderId;
            StatusId = statusId;
        }
    }
}