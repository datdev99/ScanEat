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
    public record GetAllProductsByTenantQuery(Guid tenantId) : IRequest<IEnumerable<Product>>;

    public class GetAllProductsByTenantQueryHandler : IRequestHandler<GetAllProductsByTenantQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsByTenantQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsByTenantQuery request, CancellationToken cancellationToken) => await _productRepository.GetAllByTenantAsync(request.tenantId);
    }
}
