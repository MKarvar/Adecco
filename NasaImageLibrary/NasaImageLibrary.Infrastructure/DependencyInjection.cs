

using Microsoft.Extensions.DependencyInjection;
using NasaImageLibrary.Applicationservice.Contracts;

namespace NasaImageLibrary.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(INasaExternalService), typeof(NasaExternalService));
            return services;
        }
    }
}
