using System.ComponentModel.DataAnnotations;

namespace Logistics.Management.Application.Requests
{
    public record RequestRequest
    {
        [Key]
        public Guid Id { get; set; }

        public RequestRequest() => Id = Guid.NewGuid();
    }
}