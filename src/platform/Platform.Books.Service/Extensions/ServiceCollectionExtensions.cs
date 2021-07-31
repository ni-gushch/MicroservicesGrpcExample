using MicroservicesGrpcExample.Platform.Books.DataAccess.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesGrpcExample.Platform.Books.Service.Extensions
{
    /// <summary>
    /// Extensions for instance of <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqLiteDbContextsRegistration(configuration);
            services.AddRepositoriesRegistration();

            return services;
        }
    }
}