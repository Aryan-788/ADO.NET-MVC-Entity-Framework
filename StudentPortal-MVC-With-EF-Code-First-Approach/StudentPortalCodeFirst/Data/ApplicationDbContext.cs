using Microsoft.EntityFrameworkCore;
using StudentPortalCodeFirst.Models;

namespace StudentPortalCodeFirst.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
