using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(12, MinimumLength =12, ErrorMessage = "Adhaar number must be exactly 12 characters.")]
        public string Adhaar_No { get; set; }
        
        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }
    }
}
