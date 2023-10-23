namespace Logistics.Management.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            AutomatedGuidedVehicles = new HashSet<AutomatedGuidedVehicle>();
            Goods = new HashSet<Good>();
        }

        public Guid Id { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AutomatedGuidedVehicle> AutomatedGuidedVehicles { get; set; }
        public virtual ICollection<Good> Goods { get; set; }
    }
}