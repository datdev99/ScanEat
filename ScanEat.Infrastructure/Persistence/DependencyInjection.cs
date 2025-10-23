using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ScanEat.Domain.Interfaces;
using ScanEat.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using ScanEat.Domain.Options;
using ScanEat.Infrastructure.Persistence.Data;

namespace ScanEat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
