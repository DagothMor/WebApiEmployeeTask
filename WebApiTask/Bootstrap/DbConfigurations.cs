
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiTask.Contexts;

namespace WebApiTask.Bootstrap
{
    /// <summary>
    /// Database configuration.
    /// </summary>
    public static class DbConfigurations
    {
        public static void ConfigureDb(
            this IServiceCollection services,
                    IConfiguration configuration)
        {
            var connectionString = "Server=DESKTOP-S53KNVB;Database=FirstDataBase;User Id=egg;Password=aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==;";
            services.AddDbContext<WebApiTaskContext>(
                options => options.UseSqlServer(
                connectionString,
                builder => builder.MigrationsAssembly(typeof(WebApiTaskContext).Assembly.FullName)
                ));
        }
    }
}
