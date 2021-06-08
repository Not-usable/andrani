using Application.Interfaces.Services;
using Infrastructure.ExternalServices.OpenStreetMaps;
using Infrastructure.MessageQueue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.MessageQueue;

namespace Infrastructure.Extensions.ServiceBuilder
{
    public static class ServiceBuilderExtencion
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGeoService, OpenStreetMapService>();

            services.AddTransient<IResponseQueueClient, RabitResponseQueueClient>();
        }
    }
}
