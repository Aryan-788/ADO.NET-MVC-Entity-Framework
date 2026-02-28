using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Models;
using StudentCRUD.Data;

namespace StudentCRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDAL dal;

        public StudentController(IConfiguration config)
        {
            string conn = config.GetConnectionString("DefaultConnection");
            dal = new StudentDAL(conn);
        }

        // READ
        public IActionResult Index()
        {
            var students = dal.GetAllStudents();
            return View(students);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Student student)
        {
            dal.AddStudent(student);
            return RedirectToAction("Index");
        }

        // UPDATE GET
        public IActionResult Edit(int id)
        {
            var student = dal.GetStudentById(id);
            return View(student);
        }

        // UPDATE POST
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            dal.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            dal.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}