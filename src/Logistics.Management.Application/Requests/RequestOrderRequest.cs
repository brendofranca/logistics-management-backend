using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record RequestOrderRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();

        public RequestOrderRequest() => Id = Guid.NewGuid();
    }

    public record OrderItemRequest
    {
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }
    }
}