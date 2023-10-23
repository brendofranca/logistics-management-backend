namespace Logistics.Management.Data.Models
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            Requests = new HashSet<Request>();
        }

        public Guid Id { get; set; }
        public int? StatusId { get; set; }
        public Guid? RequestId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Request? Request { get; set; }
        public virtual StatusEnum? Status { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}