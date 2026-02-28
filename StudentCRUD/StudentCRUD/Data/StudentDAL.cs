using System.Data;
using System.Data.SqlClient;
using StudentCRUD.Models;

namespace StudentCRUD.Data
{
    public class StudentDAL
    {
        private readonly string connectionString;

        public StudentDAL(string conn)
        {
            connectionString = conn;
        }

        // CREATE
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students VALUES (@Name,@Email,@Age)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Age", student.Age);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student s = new Student();

                    s.Id = Convert.ToInt32(reader["Id"]);
                    s.Name = reader["Name"].ToString();
                    s.Email = reader["Email"].ToString();
                    s.Age = Convert.ToInt32(reader["Age"]);

                    list.Add(s);
                }
            }

            return list;
        }

        // UPDATE
        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Students SET Name=@Name, Email=@Email, Age=@Age WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Age", student.Age);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET BY ID
        public Student GetStudentById(int id)
        {
            Student s = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    s.Id = Convert.ToInt32(reader["Id"]);
                    s.Name = reader["Name"].ToString();
                    s.Email = reader["Email"].ToString();
                    s.Age = Convert.ToInt32(reader["Age"]);
                }
            }

            return s;
        }
    }
}