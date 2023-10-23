namespace Logistics.Management.Application.Responses
{
    public record OrderResponse
    {
        public Guid Id { get; set; }
    }

    public record ProcessRespose
    {
        public string Message { get; set; }
    }

    public record GoodResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public record LocationRespose
    {
        public Guid Id { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
    }
}