using System.Linq;
using MicroservicesGrpcExample.Platform.Books.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess
{
    /// <summary>
    ///     Base repository class
    /// </summary>
    public class Repository<TEntity>
        where TEntity : class
    {
        public Repository(BookLibraryDbContext dbContext)
        {
            BookLibraryContext = dbContext;
            DbSet = BookLibraryContext.Set<TEntity>();
            DbSetNoTracking = DbSet.AsNoTracking();
        }

        protected BookLibraryDbContext BookLibraryContext { get; }
        protected DbSet<TEntity> DbSet { get; }
        protected IQueryable<TEntity> DbSetNoTracking { get; }
    }
}