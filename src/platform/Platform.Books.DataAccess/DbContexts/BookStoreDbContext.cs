using MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess.DbContexts
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookStoreDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}