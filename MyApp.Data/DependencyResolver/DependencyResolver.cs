using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Data.DependencyResolver
{
    public static class DependencyResolver
    {
        public static void ConfigureAppCDBContex(this IServiceCollection services)
        {
            var conStr = string.Empty;
            if (string.IsNullOrWhiteSpace(conStr))
            {
                throw new Exception("Connection string is not specified.");
            }
            services.AddDbContext<AppDbContex>(option =>
            {
                option.UseSqlServer(conStr);
            });
        }
    }
}
