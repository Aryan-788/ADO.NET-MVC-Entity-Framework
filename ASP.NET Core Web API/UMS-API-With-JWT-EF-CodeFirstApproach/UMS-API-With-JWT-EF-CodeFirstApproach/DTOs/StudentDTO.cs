namespace UMS_API_With_JWT_EF_CodeFirstApproach.DTOs
{
    public class StudentDTO
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public bool IsHostelStudent { get; set; }

        public int RoomNumber { get; set; }
    }
}
