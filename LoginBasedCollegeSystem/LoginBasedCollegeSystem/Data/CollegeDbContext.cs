using LoginBasedCollegeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginBasedCollegeSystem.Data
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<SemesterMark> SemesterMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.SemesterMarks)
                .WithOne(m => m.Student)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Student>()
                .Property(s => s.IdCardNumber)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Student>()
                .Property(s => s.Password)
                .IsRequired();
        }
    }
}
