using Microsoft.EntityFrameworkCore;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;

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

        public async Task<IEnumerable<Product>> GetAllAsync() => await _dbContext.Products.ToListAsync();

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
