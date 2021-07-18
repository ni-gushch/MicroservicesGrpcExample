using MicroservicesGrpcExample.Server.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesGrpcExample.Server.DAL
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
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