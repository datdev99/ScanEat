using MediatR;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Application.Features.Queries
{
    public record GetAllTenantsQuery() : IRequest<List<Tenant>>;

    public class GetAllTenantsQueryHandler : IRequestHandler<GetAllTenantsQuery, List<Tenant>>
    {
        private readonly ITenantRepository _tenantRepository;

        public GetAllTenantsQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task<List<Tenant>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
        {
            return await _tenantRepository.GetAllAsync();
        }
    }
}
