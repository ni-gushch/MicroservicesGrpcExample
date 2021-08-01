using MicroservicesGrpcExample.Platform.Books.Contracts.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess.DbContexts
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(it => it.Id);
            modelBuilder.Entity<Book>()
                .HasOne(it => it.Author)
                .WithMany(it => it.Books)
                .HasForeignKey(it => it.AuthorId);

            modelBuilder.Entity<Author>()
                .HasKey(it => it.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}