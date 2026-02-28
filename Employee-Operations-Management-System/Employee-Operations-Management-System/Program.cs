using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Data Source=ARYAN\\SQLEXPRESS02;Initial Catalog=Top_Brains;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";

    static void GetEmployeesByDepartment(string dept)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nEmployees in Department: " + dept);

            while (reader.Read())
            {
                Console.WriteLine(reader["EmpId"] + " | " + reader["Name"] + " | " + reader["Department"] + " | " + reader["Phone"] + " | " + reader["Email"]);
            }

            reader.Close();
        }
    }
    static void GetDepartmentEmployeeCount(string dept)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Department", dept);

            SqlParameter outputParam = new SqlParameter();
            outputParam.ParameterName = "@TotalEmployees";
            outputParam.SqlDbType = SqlDbType.Int;
            outputParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(outputParam);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("\nTotal employees in " + dept + ": " + cmd.Parameters["@TotalEmployees"].Value);
        }
    }

    static void GetEmployeeOrders()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nEmployee Order Report:");

            while (reader.Read())
            {
                Console.WriteLine(
                    reader["Name"] + " | " +
                    reader["Department"] + " | OrderID: " +
                    reader["OrderId"] + " | Amount: " +
                    reader["OrderAmount"] + " | Date: " +
                    reader["OrderDate"]);
            }

            reader.Close();
        }
    }

    static void GetDuplicateEmployees()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nDuplicate Employees:");

            while (reader.Read())
            {
                Console.WriteLine(
                    reader["EmpId"] + " | " +
                    reader["Name"] + " | " +
                    reader["Department"] + " | " +
                    reader["Phone"] + " | " +
                    reader["Email"]);
            }

            reader.Close();
        }
    }

    static void Main()
    {
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        GetEmployeesByDepartment(dept);

        GetDepartmentEmployeeCount(dept);

        GetEmployeeOrders();

        GetDuplicateEmployees();

        Console.ReadLine();
    }
}