using Logistics.Management.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Management.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly RequestRepository _requestRepository;

        public RequestController(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
            Ok(await _requestRepository.GetAllAsync(cancellationToken));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
           Ok();
    }
}