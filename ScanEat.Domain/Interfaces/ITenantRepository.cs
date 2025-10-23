using ScanEat.Domain.Entities;

namespace ScanEat.Domain.Interfaces
{
    public interface ITenantRepository
    {
        Task<Tenant> AddAsync(Tenant tenant);
        Task<Tenant> UpdateAsync(Tenant tenant);
        Task DeleteAsync(Guid tenantId);
        Task<Tenant?> GetByIdAsync(Guid tenantId);
        Task<List<Tenant>> GetAllAsync();
    }
}
