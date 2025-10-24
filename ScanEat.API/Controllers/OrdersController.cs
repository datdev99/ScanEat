using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanEat.Application.DTOs.Order;
using ScanEat.Application.Features.Commands;
using ScanEat.Application.Features.Queries;
using System.ComponentModel.DataAnnotations;

namespace ScanEat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CURD
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderDto dto)
        {
            var result = await _mediator.Send(new CreateOrderCommand(dto));
            return Ok(result);
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderById(Guid OrderId)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(OrderId));
            return Ok(result);
        }

        [HttpPut("Status/{OrderId}")]
        public async Task<IActionResult> UpdateOrderStatus([Required] Guid OrderId,[FromBody] UpdateOrderStatusDto dto)
        {
            var result = await _mediator.Send(new UpdateOrderStatusCommand(OrderId, dto));
            return Ok(result);
        }
        #endregion
    }
}
