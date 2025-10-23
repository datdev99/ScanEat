using MediatR;
using ScanEat.Application.DTOs.Order;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Application.Features.Queries
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<Order>;

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetOrderWithItemsAsync(request.Id);
            if (order == null)
                throw new Exception("Order not found");

            return order;
        }
    }
}
