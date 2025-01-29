namespace Logistics.Management.Application.Responses
{
    public record CollectOrderResponse
    {
        public string FatestRoute { get; set; } = string.Empty;
    }
}