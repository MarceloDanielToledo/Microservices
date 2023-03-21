using Consul;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace ServiceDiscovery
{
    internal class DiscoveryService : IHostedService
    {
        private readonly IConsulClient _consulClient;
        private readonly ServiceConfig _serviceConfig;
        private string _registrationId = "";

        public DiscoveryService(IConsulClient consulClient, ServiceConfig serviceConfig)
        {
            _consulClient = consulClient;
            _serviceConfig = serviceConfig;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _registrationId = $"{_serviceConfig.ServiceName}_{Guid.NewGuid():D}";
            var hostname = Dns.GetHostName();
            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _serviceConfig.ServiceName,
                Address = hostname,//_serviceConfig.ServiceAddress.Host
                Port = _serviceConfig.ServiceAddress.Port,

                Check = new AgentCheckRegistration()
                {
                    HTTP = $"{_serviceConfig.ServiceAddress.Scheme}://{hostname}:{_serviceConfig.ServiceAddress.Port}/health",
                    TTL = TimeSpan.FromSeconds(5),
                    Interval = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1)
                }
            };


            await _consulClient.Agent.ServiceDeregister(registration.ID, cancellationToken);
            await _consulClient.Agent.ServiceRegister(registration, cancellationToken);

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _consulClient.Agent.ServiceDeregister(_registrationId, cancellationToken);
        }
    }
}
