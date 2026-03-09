using LoginBasedCollegeSystem.Models;

namespace LoginBasedCollegeSystem.Repositories
{
    public interface IStudentRepository
    {
        Student Login(string idCard, string password);

        Student GetStudentMarks(int studentId);
    }
}
