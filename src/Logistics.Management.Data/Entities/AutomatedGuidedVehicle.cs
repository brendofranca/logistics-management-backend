using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class AutomatedGuidedVehicle : Entity
    {
        public string Name { get; set; }
        public Guid? LocationId { get; set; }

        public virtual Location? Location { get; set; }

        public AutomatedGuidedVehicle(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetLocationId(Guid locationId) => LocationId = locationId;
    }
}