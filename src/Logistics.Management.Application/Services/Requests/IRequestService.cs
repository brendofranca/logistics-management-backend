using Logistics.Management.Application.Responses;

namespace Logistics.Management.Application.Services.Requests
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestResponse>> GetAllRequests(CancellationToken cancellationToken);
    }
}