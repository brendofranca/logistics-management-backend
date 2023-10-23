using AutoMapper;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Repositories.Requests;

namespace Logistics.Management.Application.Services.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;

        public RequestService(IMapper mapper, IRequestRepository requestRepository)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
        }

        public async Task<IEnumerable<RequestResponse>> GetAllRequests(CancellationToken cancellationToken)
        {
            var requests = await _requestRepository.FindAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<RequestResponse>>(requests);
        }
    }
}