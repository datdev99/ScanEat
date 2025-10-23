using MediatR;
using ScanEat.Application.DTOs.Product;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;

namespace ScanEat.Application.Features.Commands
{
    public record CreateProductCommand(AddProductDto product) : IRequest<Product>;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(request.product.CategoryId);
            if(existingCategory == null)
            {
                throw new Exception("Category not found");
            }

            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.product.Name,
                Description = request.product.Description,
                Price = request.product.Price,
                CategoryId = request.product.CategoryId,
                TenantId = request.product.TenantId,
            };

            var result = await _productRepository.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
