using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record ProcessOrderRequest
    {
        [Required]
        public List<Guid> RequestIds { get; set; }
    }
}