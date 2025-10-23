
using ScanEat.Application.DTOs.Category;
using ScanEat.Application.DTOs.Product;
using ScanEat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Application.DTOs.Tenant
{
    public class TenantDto
    {
        public string Name { get; set; } = default!;
        public string Domain { get; set; } = default!;
        public string? LogoUrl { get; set; }
        public string ThemeColor { get; set; } = "#FFFFFF";
        public Guid CategoryId { get; set; }
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
        //public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        //public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
        public ICollection<RevenueReport> RevenueReports { get; set; } = new List<RevenueReport>();
        public ICollection<ProductSales> ProductSales { get; set; } = new List<ProductSales>();
    }
}
