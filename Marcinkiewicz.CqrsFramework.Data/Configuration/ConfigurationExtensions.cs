using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marcinkiewicz.CqrsFramework.Data.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            // Add database
            services.AddDbContext<DataContext>(
                options => {
                    options.UseSqlServer(connectionString);
                });

            // Register resolving by interface
            services.AddScoped<IDataContext, DataContext>();
        }
    }
}
