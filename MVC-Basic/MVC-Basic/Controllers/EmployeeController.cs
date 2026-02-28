using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Models;

namespace MVC_Basic.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Index(IFormCollection obj)
        //{
        //    ViewBag.result = "Id: " + obj["Id"] + " Name: " + obj["Name"] + " Salary: " + obj["Salary"];
        //    return View();
        //}

        public IActionResult Index(Employee obj)
        {
            ViewBag.result = "Id: " + obj.Id + " Name: " + obj.Name + " Salary: " + obj.Salary;
            return View();
        }

    }
}
