namespace Logistics.Management.Data.Models
{
    public partial class AutomatedGuidedVehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? LocationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Location? Location { get; set; }
    }
}