using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public partial class OrderItem : Entity
    {
        public Guid? OrderId { get; set; }
        public Guid? ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }

        // EF
        protected OrderItem()
        { }

        public OrderItem(Guid id, int quantity, Guid orderId, Guid itemId)
        {
            Id = id;
            Quantity = quantity;
            OrderId = orderId;
            ItemId = itemId;
        }
    }
}