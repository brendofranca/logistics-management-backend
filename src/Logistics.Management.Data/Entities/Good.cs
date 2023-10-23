using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class Good : Entity
    {
        public string Name { get; set; }
        public Guid? LocationId { get; set; }
        public int Quantity { get; set; }

        public virtual Location? Location { get; set; }
        public virtual ICollection<RequestItem> RequestItems { get; set; }

        public Good(Guid id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            RequestItems = new HashSet<RequestItem>();
        }

        public void SetLocationId(Guid locationId) => LocationId = locationId;
    }
}