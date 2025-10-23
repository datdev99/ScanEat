using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScanEat.Application.DTOs.Customer;
using ScanEat.Application.Features.Commands;

namespace ScanEat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CURD
        // Implement CRUD operations for Customer here
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerDto customer) => Ok(await _mediator.Send(new CreateCustomerCommand(customer)));

        #endregion
    }
}
