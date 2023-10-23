namespace Logistics.Management.Data.Entities
{
    public partial class StatusEnum
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }

        protected StatusEnum() => OrderStatuses = new HashSet<OrderStatus>();
    }
}