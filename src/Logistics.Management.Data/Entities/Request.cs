using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class Request : Entity
    {
        public string Description { get; set; }
        public Guid? RequestStatusId { get; set; }

        public virtual RequestStatus? RequestStatus { get; set; }
        public virtual IEnumerable<RequestItem> RequestItems { get; set; }
        public virtual IEnumerable<RequestStatus> RequestStatuses { get; set; }

        public Request(Guid id, string description)
        {
            Id = id;
            Description = description;
            RequestItems = new HashSet<RequestItem>();
            RequestStatuses = new HashSet<RequestStatus>();
        }

        public void SetRequestStatusId(Guid requestStatusId) =>
            RequestStatusId = requestStatusId;

        public void SetRequestItems(List<RequestItem> requestItems) =>
            RequestItems = requestItems;
    }
}