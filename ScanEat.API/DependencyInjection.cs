using ScanEat.Application;
using ScanEat.Domain;
using ScanEat.Infrastructure.Persistence;

namespace ScanEat.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);
                //.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
