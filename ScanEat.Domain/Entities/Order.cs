using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Guid CustomerId { get; set; }

        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "pending"; // pending / completed / cancelled

        public Tenant Tenant { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
