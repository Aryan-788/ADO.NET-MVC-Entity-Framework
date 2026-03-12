namespace UMS_API_With_JWT_EF_CodeFirstApproach.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public bool IsHostelStudent { get; set; }

        public Hostel Hostel { get; set; }
    }
}
