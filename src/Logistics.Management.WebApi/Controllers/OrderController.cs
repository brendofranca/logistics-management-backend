using Logistics.Management.Application.Factories;
using Logistics.Management.Application.Notifications;
using Logistics.Management.Application.Queries.Orders;
using Logistics.Management.Application.Requests;
using Logistics.Management.Data.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Management.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderQuery _orderService;
        private readonly IDomainNotification _domainNotification;

        public OrderController(IMediator mediator, IOrderQuery orderService, IDomainNotification domainNotification)
        {
            _mediator = mediator;
            _orderService = orderService;
            _domainNotification = domainNotification;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] Status status, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllOrders(status, cancellationToken);

            return Ok(new { Success = true, Data = result });
        }

        [HttpPost]
        public async Task<IActionResult> RequestOrder([FromBody] RequestOrderRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = OrderCommandFactory.RequestOrderCommandFromRequest(request);

            var result = await _mediator.Send(command, cancellationToken);

            return result ? Ok(new { Success = true, Data = "Order requested successfully." })
                          : BadRequest(new { success = false, Data = _domainNotification.GetNotifications().Select(n => n.Message).ToList() });
        }

        [HttpPut("{id:guid}/collect")]
        public async Task<IActionResult> CollectOrder([FromRoute] Guid id, [FromBody] CollectOrderRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            var command = OrderCommandFactory.CollectOrderCommandFromRequest(request);

            var result = await _mediator.Send(command, cancellationToken);

            return result != null ? Ok(new { Success = true, Data = result })
                          : BadRequest(new { success = false, Data = _domainNotification.GetNotifications().Select(n => n.Message).ToList() });
        }

        [HttpPut("{id:guid}/send")]
        public async Task<IActionResult> SendOrder([FromRoute] Guid id, [FromBody] SendOrderRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            var command = OrderCommandFactory.SendOrderCommandRequest(request);

            var result = await _mediator.Send(command, cancellationToken);

            return result ? Ok(new { Success = true, Data = "Order sent successfully." })
                          : BadRequest(new { success = false, Data = _domainNotification.GetNotifications().Select(n => n.Message).ToList() });
        }

        [HttpPut("{id:guid}/receive")]
        public async Task<IActionResult> ReceiveOrder([FromRoute] Guid id, [FromBody] ReceiveOrderRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            var command = OrderCommandFactory.ReceiveOrderCommandRequest(request);

            var result = await _mediator.Send(command, cancellationToken);

            return result ? Ok(new { Success = true, Data = "Order received successfully." })
                          : BadRequest(new { success = false, Data = _domainNotification.GetNotifications().Select(n => n.Message).ToList() });
        }
    }
}