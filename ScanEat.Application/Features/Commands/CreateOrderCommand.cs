using Google.Cloud.Firestore;
using MediatR;
using ScanEat.Application.DTOs.Order;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;

namespace ScanEat.Application.Features.Commands
{
    public record CreateOrderCommand(AddOrderDto Order) : IRequest<Order>;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FirestoreDb _firestore;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, FirestoreDb firestore)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _firestore = firestore;
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Order;
            var order = new Order
            {
                TenantId = dto.TenantId,
                CustomerId = dto.CustomerId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            decimal total = 0;
            foreach (var item in dto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception($"Product {item.ProductId} not found");

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                total += orderItem.TotalPrice;
                order.OrderItems.Add(orderItem);
            }

            order.TotalAmount = total;

            var resultOrder = await _orderRepository.AddOrderAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Firestore logging
            var collection = _firestore.Collection("order-notify").Document(order.TenantId.ToString()).Collection("orders");
            //await collection.AddAsync(new
            //{
            //    orderId = resultOrder.Id.ToString(),
            //    createdAt = resultOrder.CreatedAt,
            //    status = "new"
            //});
            await collection
                .Document(resultOrder.Id.ToString()) // 🔥 Trùng OrderId
                .SetAsync(new
                {
                    orderId = resultOrder.Id.ToString(),
                    createdAt = resultOrder.CreatedAt,
                    status = "new"
                });

            return resultOrder;
        }
    }
}
