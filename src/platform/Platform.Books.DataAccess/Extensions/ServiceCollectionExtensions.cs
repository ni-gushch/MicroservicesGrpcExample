using System;
using MicroservicesGrpcExample.Platform.Books.Contracts.Repositories;
using MicroservicesGrpcExample.Platform.Books.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess.Extensions
{
    /// <summary>
    /// Extensions for instance of <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqLiteDbContextsRegistration(this IServiceCollection services)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
            services.AddDbContext<BookLibraryDbContext>(opt =>
                opt.UseSqlite($"Data Source={dbPath}"));

            return services;
        }

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