namespace LoginBasedCollegeSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string IdCardNumber { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Course { get; set; }

        public ICollection<SemesterMark> SemesterMarks { get; set; }
    }
}
