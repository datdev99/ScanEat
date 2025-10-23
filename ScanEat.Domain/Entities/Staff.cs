using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class Staff : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // admin / cashier / cook
        public bool IsActive { get; set; } = true;
        public Tenant Tenant { get; set; } = default!;
    }
}
