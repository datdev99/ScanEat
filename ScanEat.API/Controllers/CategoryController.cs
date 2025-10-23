using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScanEat.Application.DTOs.Category;
using ScanEat.Application.Features.Commands;

namespace ScanEat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region CURD
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryDto category) => Ok(await _mediator.Send(new CreateCategoryCommand(category)));

        #endregion
    }
}
