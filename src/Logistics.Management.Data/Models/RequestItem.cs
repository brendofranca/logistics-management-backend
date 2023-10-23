namespace Logistics.Management.Data.Models
{
    public partial class RequestItem
    {
        public Guid Id { get; set; }
        public Guid? RequestId { get; set; }
        public Guid? GoodId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Good? Good { get; set; }
        public virtual Request? Request { get; set; }
    }
}