namespace Logistics.Management.Data.Models
{
    public partial class Good
    {
        public Good()
        {
            RequestItems = new HashSet<RequestItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? LocationId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Location? Location { get; set; }
        public virtual ICollection<RequestItem> RequestItems { get; set; }
    }
}