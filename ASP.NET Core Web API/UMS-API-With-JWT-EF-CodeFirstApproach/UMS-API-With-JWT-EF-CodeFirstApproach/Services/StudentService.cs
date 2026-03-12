using Microsoft.EntityFrameworkCore;
using UMS_API_With_JWT_EF_CodeFirstApproach.Data;
using UMS_API_With_JWT_EF_CodeFirstApproach.DTOs;
using UMS_API_With_JWT_EF_CodeFirstApproach.Models;

namespace UMS_API_With_JWT_EF_CodeFirstApproach.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudent(StudentDTO dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Department = dto.Department,
                IsHostelStudent = dto.IsHostelStudent
            };

            if (dto.IsHostelStudent)
            {
                student.Hostel = new Hostel
                {
                    RoomNumber = dto.RoomNumber
                };
            }

            _context.Students.Add(student);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(int id, int room)
        {
            var hostel = await _context.Hostels.FirstOrDefaultAsync(x => x.StudentId == id);

            if(hostel == null)
            {
                //throw new Exception("Student is not a hostel student.");

                Console.WriteLine("Student is not a hostel student.");
                return;
            }

            hostel.RoomNumber = room;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.Include(x => x.Hostel).ToListAsync();
        }

        public async Task<List<Student>> GetHostelStudents()
        {
            return await _context.Students
                .Include(x => x.Hostel)
                .Where(x => x.IsHostelStudent)
                .ToListAsync();
        }

        public async Task<List<Student>> GetNonHostelStudents()
        {
            return await _context.Students
                .Where(x => !x.IsHostelStudent)
                .ToListAsync();
        }
    }
}
