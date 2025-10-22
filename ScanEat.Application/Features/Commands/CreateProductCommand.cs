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

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.product.Name,
                Description = request.product.Description,
                Price = request.product.Price
            };

            var result = await _productRepository.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
