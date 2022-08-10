using Common.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

namespace NasaImageLibrary.API.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {

            Assert.NotNull(services, nameof(services));
            services.AddSwaggerGen(options =>
            {
                //var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "Comments.xml");
                //options.IncludeXmlComments(xmlDocPath, true);

                options.EnableAnnotations();
                options.UseInlineDefinitionsForEnums();
                options.IgnoreObsoleteActions();
                options.IgnoreObsoleteProperties();

                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1" });

            

                #region Versioning
                // Remove version parameter from all Operations
                options.OperationFilter<RemoveVersionParameters>();

                //set version "api/v{version}/[controller]" from current swagger doc verion
                options.DocumentFilter<SetVersionInPaths>();

                //Seperate and categorize end-points by doc version
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
                #endregion

            });
            services.AddFluentValidationRulesToSwagger();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            return services;
        }

        public static void UseCustomSwaggerAndUI(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));
            //Swagger middleware for generate "Open API Documentation" in swagger.json
            app.UseSwagger(options =>
            {
                //options.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                #region Customizing
                options.DocExpansion(DocExpansion.None);
                //options.OAuthClientId("SampleClientId");
                //options.OAuthClientSecret("SampleClientSecret");
                //options.InjectStylesheet("/swagger/custom.css");

                #endregion
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }
    }
}
