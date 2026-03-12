using UMS_API_With_JWT_EF_CodeFirstApproach.DTOs;
using UMS_API_With_JWT_EF_CodeFirstApproach.Models;

namespace UMS_API_With_JWT_EF_CodeFirstApproach.Services
{
    public interface IStudentService
    {
        Task AddStudent(StudentDTO dto);

        Task DeleteStudent(int id);

        Task UpdateRoom(int id, int room);

        Task<List<Student>> GetAllStudents();

        Task<List<Student>> GetHostelStudents();

        Task<List<Student>> GetNonHostelStudents();
    }
}
