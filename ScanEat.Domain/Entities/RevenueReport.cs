using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class RevenueReport : BaseEntity
    {
        public Guid TenantId { get; set; }
        public DateTime ReportDate { get; set; }

        public int TotalOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int TotalCancelled { get; set; }
        public decimal TotalRevenue { get; set; }

        public Tenant Tenant { get; set; } = default!;
    }
}
