using Microsoft.EntityFrameworkCore;
using UMS_API_With_JWT_EF_CodeFirstApproach.Models;

namespace UMS_API_With_JWT_EF_CodeFirstApproach.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
         public DbSet<Student> Students { get; set; }
        public DbSet<Hostel> Hostels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Hostel)
                .WithOne(h => h.Student)
                .HasForeignKey<Hostel>(h => h.StudentId);
        }
    }
}
