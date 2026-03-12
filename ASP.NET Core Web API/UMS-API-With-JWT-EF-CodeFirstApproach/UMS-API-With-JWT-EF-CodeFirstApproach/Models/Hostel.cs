namespace UMS_API_With_JWT_EF_CodeFirstApproach.Models
{
    public class Hostel
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
