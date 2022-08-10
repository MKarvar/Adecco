using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace NasaImageLibrary.Infrastructure
{
    public static class RefitServiceExtension
    {
        public static IServiceCollection AddCustomRefitClients(this IServiceCollection services, IConfiguration configuration)
        {
            var nasaUrl = configuration.GetSection("AppSettings:NasaLibraryUrl")?.Value;
            services.AddCustomRefitClient<INasaImageAndVideoLibraryClient>(nasaUrl);

            return services;
        }

        private static void AddCustomRefitClient<T>(this IServiceCollection services, string url, int timeOut = 2) where T : class
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            services.AddRefitClient<T>(refitSettings)
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
                .SetHandlerLifetime(TimeSpan.FromMinutes(timeOut));
        }
    }

}
