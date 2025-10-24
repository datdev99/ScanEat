using Google.Cloud.Firestore;
using MediatR;
using ScanEat.Application.DTOs.Order;
using ScanEat.Domain.Interfaces;

namespace ScanEat.Application.Features.Commands
{
    public record UpdateOrderStatusCommand(Guid OrderId, UpdateOrderStatusDto dto) : IRequest<bool>;

    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FirestoreDb _firestore;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository, ITenantRepository tenantRepository, IUnitOfWork unitOfWork, FirestoreDb firestore)
        {
            _orderRepository = orderRepository;
            _tenantRepository = tenantRepository;
            _unitOfWork = unitOfWork;
            _firestore = firestore;
        }
        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var existingTenant = await _tenantRepository.GetByIdAsync(request.dto.TenantId);
            if (existingTenant == null)
            {
                return false;
            }
            await _orderRepository.UpdateOrderStatusAsync(request.OrderId, request.dto.Status);
            await _unitOfWork.SaveChangesAsync();

            try
            {
                await _firestore
                    .Collection("order-notify")
                    .Document(request.dto.TenantId.ToString())
                    .Collection("orders")
                    .Document(request.OrderId.ToString())
                    .DeleteAsync(cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                 throw new Exception("Failed to delete Firestore document", ex);
            }


            return true;
        }
    }
}
