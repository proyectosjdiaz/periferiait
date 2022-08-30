using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Periferia.Application.Common.Repository;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Infrastructure.Context;
using Periferia.Infrastructure.Repository;
using Periferia.Infrastructure.Service.Customer;
using Periferia.Infrastructure.Service.Order;
using System.Net.Http.Headers;

namespace Periferia.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("ConnectionString")); });
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddHttpClient("CustomerApi", config =>
            {
                config.BaseAddress = new Uri(configuration["Api:CustomerApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient("ProductApi", config =>
            {
                config.BaseAddress = new Uri(configuration["Api:ProductApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
