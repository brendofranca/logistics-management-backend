using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record OrderItemRequest
    {
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }
    }
}