using ScanEat.Domain.Entities;

namespace ScanEat.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<Category?> GetByIdAsync(Guid id);
    }
}
