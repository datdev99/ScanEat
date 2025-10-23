using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using ScanEat.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Infrastructure.Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            return category;
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if(category == null)
            {
                return null;
            }
            return category;
        }
    }
}
