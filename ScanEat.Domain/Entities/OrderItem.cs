using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public Order Order { get; set; } = default!;
        public Product Product { get; set; } = default!;
    }
}
