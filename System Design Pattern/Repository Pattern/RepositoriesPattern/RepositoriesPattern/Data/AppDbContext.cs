using Microsoft.EntityFrameworkCore;
using RepositoriesPattern.Models;

namespace RepositoriesPattern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("TblStudentMaster");
        }
    }
}
