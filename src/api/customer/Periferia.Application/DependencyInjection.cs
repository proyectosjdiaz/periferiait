using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Periferia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).GetTypeInfo().Assembly);

            return services;
        }
    }
}
