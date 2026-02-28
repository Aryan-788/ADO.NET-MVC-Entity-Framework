using Microsoft.AspNetCore.Mvc;

namespace MVC_Basic.Controllers
{
    public class AdditionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection obj)
        {
            int num1 = Convert.ToInt32(obj["num1"].ToString());
            int num2 = Convert.ToInt32(obj["num2"].ToString());
            int num3 = num1 + num2;

            ViewBag.result = num3;
            return View();
        }
    }
}
