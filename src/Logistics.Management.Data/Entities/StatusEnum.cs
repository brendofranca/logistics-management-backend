namespace Logistics.Management.Data.Entities
{
    public class StatusEnum
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<RequestStatus> RequestStatuses { get; set; }

        public StatusEnum(int id, string statusName)
        {
            Id = id;
            StatusName = statusName;
            RequestStatuses = new HashSet<RequestStatus>();
        }
    }
}