using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScanEat.Application.DTOs.Tenant;
using ScanEat.Application.Features.Commands;
using ScanEat.Application.Features.Queries;

namespace ScanEat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TenantController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region CURD
        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] AddTenantDto tenant) => Ok(await _mediator.Send(new CreateTenantCommand(tenant)));

        [HttpGet]
        public async Task<IActionResult> GetAllTenants()
        {
            var tenants = await _mediator.Send(new GetAllTenantsQuery());
            var tenantDto = _mapper.Map<List<TenantDto>>(tenants);
            return Ok(tenantDto);
        }
        #endregion
    }
}
