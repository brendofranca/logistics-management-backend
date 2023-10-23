namespace Logistics.Management.Data.Models
{
    public partial class Request
    {
        public Request()
        {
            RequestItems = new HashSet<RequestItem>();
            RequestStatuses = new HashSet<RequestStatus>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public Guid? RequestStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual RequestStatus? RequestStatus { get; set; }
        public virtual ICollection<RequestItem> RequestItems { get; set; }
        public virtual ICollection<RequestStatus> RequestStatuses { get; set; }
    }
}