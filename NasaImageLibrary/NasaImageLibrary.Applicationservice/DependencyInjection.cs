using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NasaImageLibrary.Applicationservice.Queries;

namespace NasaImageLibrary.Applicationservice
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<SearchFilesQuery>());
            return services;
        }
    }
}

