using Microsoft.Extensions.DependencyInjection;
using MyApp.Serviecs.Interfaces;
using MyApp.Serviecs.Services;

namespace MyApp.Infrastructure.ServicesExtension
{
    public static class ServicesExtension
    {
        public static void RegisteredServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserServices>();
        }

    }
}
