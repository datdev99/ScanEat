using Microsoft.EntityFrameworkCore;
using ScanEat.Application.DTOs.Category;
using ScanEat.Application.DTOs.Product;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using ScanEat.Infrastructure.Persistence.Data;

namespace ScanEat.Infrastructure.Persistence.Repository
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _dbContext;

        public TenantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tenant> AddAsync(Tenant tenant)
        {
            await _dbContext.Tenants.AddAsync(tenant);
            return tenant;
        }

        public Task DeleteAsync(Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tenant>> GetAllAsync() 
            => await _dbContext.Tenants
            .Include(c => c.Categories)
            .Include(p => p.Products)
            .ToListAsync();

        public async Task<Tenant?> GetByIdAsync(Guid tenantId)
        {
            var tenant = await _dbContext.Tenants.FindAsync(tenantId);
            if(tenant == null)
            {
                return null;
            }
            return tenant;
        }

        public Task<Tenant> UpdateAsync(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
