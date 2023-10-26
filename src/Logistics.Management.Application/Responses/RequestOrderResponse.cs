namespace Logistics.Management.Application.Responses
{
    public record RequestOrderResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}