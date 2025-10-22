using Microsoft.EntityFrameworkCore;
using ScanEat.Domain.Entities;

namespace ScanEat.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<RevenueReport> RevenueReports { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Áp dụng cho tất cả entity có TenantId (trừ Tenant)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                if (clrType == typeof(Tenant))
                    continue;

                if (entityType.FindProperty("TenantId") != null)
                {
                    modelBuilder.Entity(clrType)
                        .HasIndex("TenantId");

                    modelBuilder.Entity(clrType)
                        .HasOne(typeof(Tenant))
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction); // 🚀 Rất quan trọng
                }
            }


            // Cấu hình riêng nếu cần (ví dụ Product → Category)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductSales>()
                .HasOne(o => o.Tenant)
                .WithMany(c => c.ProductSales)
                .HasForeignKey(o => o.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductSales>()
               .HasOne(o => o.Product)
               .WithMany(c => c.ProductSales)
               .HasForeignKey(o => o.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Staff>()
                .HasOne(o => o.Tenant)
                .WithMany(c => c.Staffs)
                .HasForeignKey(o => o.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RevenueReport>()
                .HasOne(o => o.Tenant)
                .WithMany(c => c.RevenueReports)
                .HasForeignKey(o => o.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
