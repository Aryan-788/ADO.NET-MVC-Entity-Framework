using CollegeWebAPI.DTO;
using CollegeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpPost("createStudent")]
        public IActionResult CreateStudent(CreateStudentDTO request)
        {
            Student student = new Student
            {
                Id = students.Count + 1,
                Name = request.Name,
                Age = request.Age,
                
            };

            students.Add(student);

            return Ok(student.Id);

        }

        [HttpPut("updateStudent")]
        public IActionResult UpdateStudent(UpdateStudent request)
        {
            var student = students.FirstOrDefault(s => s.Id == request.Id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            student.M1 = request.M1;
            student.M2 = request.M2;
            student.Total = student.M1 + student.M2;
            if (student.Total >= 90)
            {
                student.Grade = "A";
            }
            else if (student.Total >= 80)
            {
                student.Grade = "B";
            }
            else if (student.Total >= 70)
            {
                student.Grade = "C";
            }
            else if (student.Total >= 60)
            {
                student.Grade = "D";
            }
            else
            {
                student.Grade = "F";
            }
            return Ok("Student updated successfully.");
        }

        // GET: api/student/
        [HttpGet("getstudent")]
        public ActionResult<List<GetResultByIdDTO>> GetStudents(int id)
        {
            var result = students.FirstOrDefault(s => s.Id == id);

            if (result == null)
            {
                return NotFound("Student not found.");
            }

            GetResultByIdDTO student = new GetResultByIdDTO
            {
                Id = result.Id,
                Name = result.Name,
                M1 = result.M1,
                M2 = result.M2,
                Total = result.Total,
                Grade = result.Grade
            };

            return Ok(student);
        }
    }
}
