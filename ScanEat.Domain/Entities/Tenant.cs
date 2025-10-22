using ScanEat.Domain.Common;

namespace ScanEat.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Domain { get; set; } = default!;
        public string? LogoUrl { get; set; }
        public string ThemeColor { get; set; } = "#FFFFFF";

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
        public ICollection<RevenueReport> RevenueReports { get; set; } = new List<RevenueReport>();
        public ICollection<ProductSales> ProductSales { get; set; } = new List<ProductSales>();
    }
}
