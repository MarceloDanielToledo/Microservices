using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceDiscovery
{
    public static class ConsulRegisterServiceExtensions
    {

        public static IServiceCollection RegisterConsulServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceConfig = configuration.GetSection("ServiceConfig").Get<ServiceConfig>();
            if (serviceConfig == null)
            {
                throw new ArgumentNullException(nameof(serviceConfig));
            }

            // set Discovery Address
            var consulClient = new ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            });

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IHostedService, DiscoveryService>();
            services.AddSingleton<IConsulClient, ConsulClient>(e => consulClient);
            return services;
        }

    }
}
