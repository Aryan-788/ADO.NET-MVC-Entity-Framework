using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    public static void Main()
    {
        Console.Write("Enter Student Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Student Marks: ");
        int marks = int.Parse(Console.ReadLine());

        string connectionString = "Data Source=ARYAN\\SQLEXPRESS02;Initial Catalog=Top_Brains;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "Insert into Student (Id, Name, Marks) Values (@Id, @Name, @Marks)";
            

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Marks", marks);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Inserted Successfully!");
                }catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }              

                
            }

            

        }

    }
}