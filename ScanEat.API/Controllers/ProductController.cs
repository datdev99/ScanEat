using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanEat.Application.DTOs.Product;
using ScanEat.Application.Features.Commands;
using ScanEat.Application.Features.Queries;

namespace ScanEat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CURD
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto product) => Ok(await _mediator.Send(new CreateProductCommand(product)));

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() => Ok(await _mediator.Send(new GetAllProductsQuery()));

        #endregion
    }
}
