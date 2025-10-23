using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; }

        public Tenant Tenant { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
