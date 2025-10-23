using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScanEat.Application.DTOs.Order;
using ScanEat.Application.Features.Commands;
using ScanEat.Application.Features.Queries;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(result);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderDto dto)
        //{
        //    var result = await _mediator.Send(new UpdateOrderCommand(id, dto));
        //    return Ok(result);
        //}
        #endregion
    }
}
