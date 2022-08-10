using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NasaImageLibrary.Infrastructure;
using Refit;
using System;


namespace NasaImageLibrary.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             //.ConfigureServices((_, services) =>
             //{
             //    services.AddRefitClient<INasaImageAndVideoLibraryClient>()
             //        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://images-api.nasa.gov/s"));
             //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
