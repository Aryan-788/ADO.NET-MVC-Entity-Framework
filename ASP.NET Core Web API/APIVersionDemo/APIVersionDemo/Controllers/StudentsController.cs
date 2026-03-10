using Microsoft.AspNetCore.Mvc;

namespace APIVersionDemo.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<string>
        {
            "Arun",
            "Kumar",
            "Divya"
        };

            return Ok(students);
        }
    }
}
