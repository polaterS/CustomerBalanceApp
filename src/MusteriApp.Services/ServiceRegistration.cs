using Microsoft.Extensions.DependencyInjection;
using MusteriApp.Data.Repositories.Implementation;
using MusteriApp.Data.Repositories.Interface;
using MusteriApp.Services.Implementation;
using MusteriApp.Services.Interface;

namespace MusteriApp.Services
{
    public static class ServiceRegistration
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            // Repository registration
            services.AddScoped<IMusteriRepository, MusteriRepository>();
            services.AddScoped<IFaturaRepository, FaturaRepository>();

            // Service registration
            services.AddScoped<IMusteriService, MusteriService>();
            services.AddScoped<IFaturaService, FaturaService>();
        }
    }
}
