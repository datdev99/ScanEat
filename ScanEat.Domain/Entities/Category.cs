using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public Tenant Tenant { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
