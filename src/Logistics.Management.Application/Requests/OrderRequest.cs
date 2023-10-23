using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record OrderRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public List<OrderItemRequest> Items { get; set; }

        public OrderRequest() => Id = Guid.NewGuid();
    }
}