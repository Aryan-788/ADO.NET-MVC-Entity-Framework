namespace LoginBasedCollegeSystem.Models
{
    public class SemesterMark
    {
        public int Id { get; set; }

        public int SemesterNumber { get; set; }

        public string Subject { get; set; }

        public int Marks { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
