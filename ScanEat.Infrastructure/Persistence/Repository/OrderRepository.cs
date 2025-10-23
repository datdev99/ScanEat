using Microsoft.EntityFrameworkCore;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using ScanEat.Infrastructure.Persistence.Data;

namespace ScanEat.Infrastructure.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            return order;
        }

        public async Task<Order?> GetOrderWithItemsAsync(Guid id)
        {
            return await _dbContext.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
