using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Periferia.Migrations.Context;

namespace Periferia.Migrations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMigrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MigrationDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: configuration.GetConnectionString("ConnectionString"),
                    sqlServerOptionsAction: b => b.MigrationsAssembly(typeof(MigrationDbContext).Assembly.FullName));
            });

            return services;
        }

        public static void EnsureMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<MigrationDbContext>();
            context?.Database.Migrate();
        }
    }
}
