using LoginBasedCollegeSystem.Models;

namespace LoginBasedCollegeSystem.Services
{
    public interface IStudentService
    {
        Student Login(string idCard, string password);

        Student GetStudentMarks(int studentId);
    }
}
