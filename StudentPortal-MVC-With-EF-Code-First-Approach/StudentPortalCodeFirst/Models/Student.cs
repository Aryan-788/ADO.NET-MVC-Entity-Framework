using System.ComponentModel.DataAnnotations;

namespace StudentPortalCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
