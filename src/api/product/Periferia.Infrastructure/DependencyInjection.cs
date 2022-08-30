using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Periferia.Application.Common.Repository;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Infrastructure.Context;
using Periferia.Infrastructure.Repository;

namespace Periferia.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("ConnectionString")); });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
