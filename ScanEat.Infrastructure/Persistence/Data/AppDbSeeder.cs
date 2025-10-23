using ScanEat.Domain.Entities;

namespace ScanEat.Infrastructure.Persistence.Data
{
    public class AppDbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Tenants.Any())
            {
                var tenants = new List<Tenant>
                {
                    new Tenant
                    {
                        Id = Guid.Parse("3239AB82-4E31-4E1A-9BF3-BCF6F136C2A1"),
                        Name = "Karinox",
                        Domain = "Karinox.com"
                    },
                    new Tenant
                    {
                        Id = Guid.Parse("77C893A1-88F8-4A79-B08C-871D42BC051D"),
                        Name = "MayCha",
                        Domain = "Maycha.com"
                    }
                };

                context.Tenants.AddRange(tenants);
                await context.SaveChangesAsync();
            }

            if(!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = Guid.Parse("A1F5D6C3-2B4E-4D8F-9C6E-1D2F3A4B5C6D"),
                        Name = "Cà phê",
                        TenantId = Guid.Parse("3239AB82-4E31-4E1A-9BF3-BCF6F136C2A1")
                    },
                    new Category
                    {
                        Id = Guid.Parse("B2E6F7D4-3C5F-5E9E-0A7B-2E3F4C5D6E7F"), // ✅ thay bằng hex hợp lệ
                        Name = "Trà sữa",
                        TenantId = Guid.Parse("77C893A1-88F8-4A79-B08C-871D42BC051D")
                    }
                };
                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            if(!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Id = Guid.Parse("C3F7E8A5-4D6E-6F0A-1B8C-3F4D5E6F7A8B"), // ✅
                        Name = "Cà phê sữa đá",
                        Price = 30000,
                        CategoryId = Guid.Parse("A1F5D6C3-2B4E-4D8F-9C6E-1D2F3A4B5C6D"),
                        TenantId = Guid.Parse("3239AB82-4E31-4E1A-9BF3-BCF6F136C2A1")
                    },
                    new Product
                    {
                        Id = Guid.Parse("D4A8B9C6-5E7F-7A1B-2C9D-4E5F6A7B8C9D"), // ✅
                        Name = "Trà sữa trân châu",
                        Price = 40000,
                        CategoryId = Guid.Parse("B2E6F7D4-3C5F-5E9E-0A7B-2E3F4C5D6E7F"),
                        TenantId = Guid.Parse("77C893A1-88F8-4A79-B08C-871D42BC051D")
                    }
                };
                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
