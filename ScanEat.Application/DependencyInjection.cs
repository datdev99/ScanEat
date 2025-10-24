using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using ScanEat.Application.Services;

namespace ScanEat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.NotificationPublisher = new TaskWhenAllPublisher();
            });

            services.AddHostedService<FirebaseCleanupService>();

            return services;
        }
    }
}
