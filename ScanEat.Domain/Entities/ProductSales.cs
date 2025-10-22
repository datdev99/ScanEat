using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class ProductSales : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Date { get; set; }

        public int QuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }

        public Tenant Tenant { get; set; } = default!;
        public Product Product { get; set; } = default!;
    }
}
