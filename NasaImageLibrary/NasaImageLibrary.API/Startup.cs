using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NasaImageLibrary.API.CustomExtensions;
using NasaImageLibrary.Applicationservice;
using NasaImageLibrary.Infrastructure;
using NasaImageLibrary.API.Swagger;

namespace NasaImageLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomCors()
                .AddCustomMvc()
                .AddCustomSwagger()
                .AddApplication()
                .AddCustomRefitClients(Configuration)
                .AddInfrastructureDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseCustomExceptionHandler();
            app.UseSwagger();
            app.UseCustomSwaggerAndUI();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
           
        }
    }
}
