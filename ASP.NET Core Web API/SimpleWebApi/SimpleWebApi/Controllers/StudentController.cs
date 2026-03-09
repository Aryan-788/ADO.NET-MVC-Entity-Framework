using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models;

namespace SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudent()
        {
            var student = new List<Student>()
            {
                new Student() { Id = 1, Name = "John Doe", Marks = 85 },
                new Student() { Id = 2, Name = "Jane Smith", Marks = 92 },
                new Student() { Id = 3, Name = "Michael Johnson", Marks = 78 },
            };

            return Ok(student);
        }
    }
}
