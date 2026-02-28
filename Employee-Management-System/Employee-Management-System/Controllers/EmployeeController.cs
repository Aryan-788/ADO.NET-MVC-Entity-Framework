
using Employee_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employee (NAME, ADHAAR_NO, DOB, SALARY) VALUES (@NAME, @ADHAAR_NO, @DOB, @SALARY)";

                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@NAME", employee.Name);
                    command.Parameters.AddWithValue("@ADHAAR_NO", employee.Adhaar_No);
                    command.Parameters.AddWithValue("@DOB", employee.DOB);
                    command.Parameters.AddWithValue("@SALARY", employee.Salary);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }

            ViewBag.Message = "Employee created successfully!";

            return View();
        }
    }
}
