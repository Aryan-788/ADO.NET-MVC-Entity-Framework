using LoginBasedCollegeSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginBasedCollegeSystem.Controllers
{
    [Route("marks")]
    public class MarksController : Controller
    {
        private readonly IStudentService _service;

        public MarksController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("my")]
        public IActionResult Index()
        {
            int studentId = HttpContext.Session.GetInt32("StudentId").Value;

            var student = _service.GetStudentMarks(studentId);

            return View(student);
        }
    }
}
