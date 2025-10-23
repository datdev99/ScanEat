using ScanEat.Domain.Entities;

namespace ScanEat.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderWithItemsAsync(Guid id);
        Task<Order> AddOrderAsync(Order order);
    }
}
