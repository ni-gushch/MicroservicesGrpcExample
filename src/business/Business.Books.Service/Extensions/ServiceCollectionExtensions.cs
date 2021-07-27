using System;
using System.IO;
using System.Reflection;
using MicroservicesGrpcExample.Client.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace MicroservicesGrpcExample.Client.Extensions
{
    /// <summary>
    /// Extension class that encapsulated settings and services in service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add custom options to service collection
        /// </summary>
        /// <param name="services">Original instance of <see cref="IServiceCollection"/></param>
        /// <param name="configuration">Instance of <see cref="IConfiguration"/></param>
        /// <returns>Original instance of <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddCustomOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ServiceConfiguration>(configuration.GetSection(nameof(ServiceConfiguration)));

            return services;
        }

        /// <summary>
        /// Add Swagger to service and configure it
        /// </summary>
        /// <param name="services">Original instance of <see cref="IServiceCollection"/></param>
        /// <param name="configuration">Instance of <see cref="IConfiguration"/></param>
        /// <returns>Original instance of <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services,
            IConfiguration configuration)
        {
            var serviceConfiguration =
                configuration.GetSection(nameof(ServiceConfiguration)).Get<ServiceConfiguration>();
            if (serviceConfiguration == null)
                throw new Exception($"Configuration {typeof(ServiceConfiguration)} is not added, check appsettings");
            
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(serviceConfiguration.Version, new OpenApiInfo()
                {
                    Version = serviceConfiguration.Version,
                    Title = serviceConfiguration.Name,
                    Description = serviceConfiguration.Description,
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddCustomLoggig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(opt =>
            {
                opt.SetMinimumLevel(LogLevel.Trace);
                opt.AddConsole();
            });

            return services;
        }
    }
}