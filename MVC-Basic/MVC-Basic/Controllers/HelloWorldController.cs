using Microsoft.AspNetCore.Mvc;

namespace MVC_Basic.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMarks(int m1, int m2, int m3) {
            int sum = m1 + m2 + m3;

            return View(sum);

        }
    }
}
