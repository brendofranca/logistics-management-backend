namespace Logistics.Management.Application.Responses
{
    public record GoodResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}