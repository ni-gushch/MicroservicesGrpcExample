using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesGrpcExample.Platform.Books.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Register application business logic services
        /// </summary>
        /// <param name="services">Instance of <see cref="IServiceCollection" /></param>
        /// <returns>Original instance of <see cref="IServiceCollection" /></returns>
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            return services;
        }
    }
}