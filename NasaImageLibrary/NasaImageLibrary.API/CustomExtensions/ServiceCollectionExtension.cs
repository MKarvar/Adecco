

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace NasaImageLibrary.API.CustomExtensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {

            services.AddMvc()
             .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
             .AddControllersAsServices();

            return services;
        }
    }
}
