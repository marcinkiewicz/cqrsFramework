using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marcinkiewicz.CqrsFramework.Data.Configuration
{
    /// <summary>
    /// Class containing <see cref="IServiceCollection"/> extensions 
    /// to register database in the IoC container.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds database access implementation to the services collection
        /// </summary>
        /// <param name="services">Services collection</param>
        /// <param name="connectionString">Connection string</param>
        public static void RegisterDatabase(this IServiceCollection services, string connectionString)
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
