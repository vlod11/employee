using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace Web.Extensions.StartupExtensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPositionService, PositionService>();
        }
    }
}