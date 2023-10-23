using Logistics.Management.Application.Requests;
using Logistics.Management.Application.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Management.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) =>
            _orderService = orderService;

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken) =>
            Ok(await _orderService.GetAllOrders(cancellationToken));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRequestById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetOrderById(id, cancellationToken);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.InsertOrder(request, cancellationToken);

            return result ? Ok() : BadRequest(result);
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessOrder([FromBody] ProcessOrderRequest request)
        {
            return Ok();
        }
    }
}