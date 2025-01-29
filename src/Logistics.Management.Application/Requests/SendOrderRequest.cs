using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record SendOrderRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}