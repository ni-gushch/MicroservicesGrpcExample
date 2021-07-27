using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess.Extensions
{
    /// <summary>
    /// Extensions for instance of <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register repositories for current service
        /// </summary>
        /// <param name="services">Instance of <see cref="IServiceCollection"/></param>
        /// <returns>Original instance of <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddRepositoriesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            
            return services;
        }
    }
}