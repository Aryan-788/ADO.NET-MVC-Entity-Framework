using LoginBasedCollegeSystem.Services;
using LoginBasedCollegeSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginBasedCollegeSystem.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IStudentService _service;

        public AuthController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginVM model)
        {
            var student = _service.Login(model.IdCardNumber, model.Password);

            if (student == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }

            HttpContext.Session.SetInt32("StudentId", student.StudentId);

            return RedirectToAction("Index", "Marks");
        }
    }
}
