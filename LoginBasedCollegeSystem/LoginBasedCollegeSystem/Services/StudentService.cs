using LoginBasedCollegeSystem.Models;
using LoginBasedCollegeSystem.Repositories;

namespace LoginBasedCollegeSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Student Login(string idCard, string password)
        {
            return _repository.Login(idCard, password);
        }

        public Student GetStudentMarks(int studentId)
        {
            return _repository.GetStudentMarks(studentId);
        }
    }
}
