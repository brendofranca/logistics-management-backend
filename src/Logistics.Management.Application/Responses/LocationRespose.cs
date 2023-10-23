namespace Logistics.Management.Application.Responses
{
    public record LocationRespose
    {
        public Guid Id { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
    }
}