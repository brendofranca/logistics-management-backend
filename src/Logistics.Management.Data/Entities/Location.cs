using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class Location : Entity
    {
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }

        public virtual ICollection<AutomatedGuidedVehicle>? AutomatedGuidedVehicles { get; set; }
        public virtual ICollection<Item>? Items { get; set; }

        // EF
        protected Location()
        {
            AutomatedGuidedVehicles = new HashSet<AutomatedGuidedVehicle>();
            Items = new HashSet<Item>();
        }

        public Location(Guid id, decimal locationX, decimal locationY)
        {
            Id = id;
            LocationX = locationX;
            LocationY = locationY;
        }
    }
}