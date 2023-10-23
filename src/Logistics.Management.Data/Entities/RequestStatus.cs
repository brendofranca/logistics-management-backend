using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public partial class RequestStatus : Entity
    {
        public int? StatusId { get; set; }
        public Guid? RequestId { get; set; }

        public virtual Request? Request { get; set; }
        public virtual StatusEnum? Status { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

        public RequestStatus(Guid id)
        {
            Id = id;
            Requests = new HashSet<Request>();
        }

        public void SetStatusId(int statusId) => StatusId = statusId;

        public void SetRequestId(Guid requestId) => RequestId = requestId;
    }
}