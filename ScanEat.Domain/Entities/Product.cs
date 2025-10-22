using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Guid CategoryId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Tenant Tenant { get; set; } = default!;
        public Category Category { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<ProductSales> ProductSales { get; set; } = new List<ProductSales>();
    }
}
