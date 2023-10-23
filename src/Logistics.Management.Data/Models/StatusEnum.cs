namespace Logistics.Management.Data.Models
{
    public partial class StatusEnum
    {
        public StatusEnum()
        {
            RequestStatuses = new HashSet<RequestStatus>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<RequestStatus> RequestStatuses { get; set; }
    }
}