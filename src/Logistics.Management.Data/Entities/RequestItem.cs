using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class RequestItem : Entity
    {
        public Guid? RequestId { get; set; }
        public Guid? GoodId { get; set; }
        public int Quantity { get; set; }

        public virtual Good? Good { get; set; }
        public virtual Request? Request { get; set; }

        public RequestItem(Guid id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public void SetRequestId(Guid requestId) => RequestId = requestId;

        public void SetGoodId(Guid goodId) => GoodId = goodId;
    }
}