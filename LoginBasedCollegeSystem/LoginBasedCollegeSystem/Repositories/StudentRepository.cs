using LoginBasedCollegeSystem.Data;
using LoginBasedCollegeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginBasedCollegeSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDbContext _context;

        public StudentRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public Student Login(string idCard, string password)
        {
            return _context.Students
                .FirstOrDefault(s => s.IdCardNumber == idCard && s.Password == password);
        }

        public Student GetStudentMarks(int studentId)
        {
            return _context.Students
                .Include(s => s.SemesterMarks)
                .FirstOrDefault(s => s.StudentId == studentId);
        }
    }
}
