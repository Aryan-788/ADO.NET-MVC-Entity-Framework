using LibrarySystem_RepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem_RepositoryPattern.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("TblBookMaster");
        }
    }
}
