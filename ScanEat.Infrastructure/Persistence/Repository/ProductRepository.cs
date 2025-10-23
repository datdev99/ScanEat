using Microsoft.EntityFrameworkCore;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using ScanEat.Infrastructure.Persistence.Data;

namespace ScanEat.Infrastructure.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            return product;
        }

        //public async Task<IEnumerable<Product>> GetAllAsync() => await _dbContext.Products.ToListAsync();

        public async Task<IEnumerable<Product>> GetAllByTenantAsync(Guid tenantId) => await _dbContext.Products.Where(p => p.TenantId == tenantId).ToListAsync();

        public async Task<Product?> GetByIdAsync(Guid id) => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}
