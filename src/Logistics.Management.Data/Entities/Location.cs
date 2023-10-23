using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class Location : Entity
    {
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }

        public virtual ICollection<AutomatedGuidedVehicle> AutomatedGuidedVehicles { get; set; }
        public virtual ICollection<Good> Goods { get; set; }

        public Location(Guid id, decimal locationX, decimal locationY)
        {
            Id = id;
            LocationX = locationX;
            LocationY = locationY;
            AutomatedGuidedVehicles = new HashSet<AutomatedGuidedVehicle>();
            Goods = new HashSet<Good>();
        }
    }
}