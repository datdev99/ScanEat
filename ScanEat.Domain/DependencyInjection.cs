using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScanEat.Domain.Options;

namespace ScanEat.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

            return services;
        }
    }
}
