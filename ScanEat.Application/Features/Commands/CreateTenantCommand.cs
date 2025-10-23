using MediatR;
using ScanEat.Application.DTOs.Tenant;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Application.Features.Commands
{
    public record CreateTenantCommand(AddTenantDto tenant) : IRequest<Tenant>;

    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Tenant>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTenantCommandHandler(ITenantRepository tenantRepository, IUnitOfWork unitOfWork)
        {
            _tenantRepository = tenantRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Tenant> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var newTenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Name = request.tenant.Name,
                Domain = request.tenant.Domain
            };
            var result = await _tenantRepository.AddAsync(newTenant);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
