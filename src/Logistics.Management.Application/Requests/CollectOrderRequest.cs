using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record CollectOrderRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid AvgId { get; set; }
    }
}