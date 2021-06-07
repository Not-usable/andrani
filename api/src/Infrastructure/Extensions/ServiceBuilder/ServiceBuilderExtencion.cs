using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Contexts;
using Infrastructure.ExternalServices.OpenStreetMaps;
using Infrastructure.MessageQueue;
using Infrastructure.Repository.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.ServiceBuilder
{
    public static class ServiceBuilderExtencion
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BasicDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Andreani.api")));

            services.AddTransient<IGeoRequestRepository, GeoRequestRepository>();

            services.AddTransient<IGeoService, OpenStreetMapService>();

            services.AddTransient<IQueueClient, RabitQueueClient>();
        }
    }
}
