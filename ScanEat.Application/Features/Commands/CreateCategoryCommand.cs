using MediatR;
using ScanEat.Application.DTOs.Category;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Application.Features.Commands
{
    public record CreateCategoryCommand(AddCategoryDto category) : IRequest<Category>;

    public class CategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                TenantId = request.category.TenantId ?? Guid.Empty,
                Name = request.category.Name,
                Description = request.category.Description
            };
            var result = await _categoryRepository.AddAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
