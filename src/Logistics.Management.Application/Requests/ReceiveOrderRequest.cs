using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record ReceiveOrderRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}