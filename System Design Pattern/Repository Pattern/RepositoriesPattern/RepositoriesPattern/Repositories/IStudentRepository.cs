using RepositoriesPattern.Models;

namespace RepositoriesPattern.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
    }
}
