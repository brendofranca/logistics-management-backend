using Logistics.Management.Data.Entities.Abstractions;

namespace Logistics.Management.Data.Entities
{
    public class AutomatedGuidedVehicle : Entity
    {
        public string Name { get; set; } = null!;
        public Guid? LocationId { get; set; }

        public virtual Location? Location { get; set; }
    }
}