using ScanEat.Domain.Entities;

namespace ScanEat.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllByTenantAsync(Guid tenantId);
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> AddAsync(Product product);
    }
}
