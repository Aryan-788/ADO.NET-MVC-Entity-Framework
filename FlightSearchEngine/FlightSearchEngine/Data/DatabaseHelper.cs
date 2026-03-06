using FlightSearchEngine.Models;
using System.Data;
using System.Data.SqlClient;

namespace FlightSearchEngine.Data
{
    public class DatabaseHelper
    {
        private string _connectionString;

        public DatabaseHelper(IConfiguration connection)
        {
            _connectionString = connection.GetConnectionString("DefaultConnection");
        }

        public async Task<List<string>> GetSourcesAsync()
        {
            List<string> sourceList = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetSources", connection);
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    sourceList.Add(reader["Source"].ToString());
                }

            }

            return sourceList;
        }

        public async Task<List<string>> GetDestinationsAsync()
        {
            List<string> destinationList = new List<string>();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetDestination", connection);
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while(await reader.ReadAsync())
                {
                    destinationList.Add(reader["Destination"].ToString());
                }
            }

            return destinationList;

        }

        public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
        {
            List<FlightResult> results = new List<FlightResult>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("sp_SearchFlights", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@Persons", persons);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while(await reader.ReadAsync())
                {
                    results.Add(new FlightResult() {FlightId = (int)reader["FlightId"], FlightName = reader["FlightName"].ToString(), FlightType = reader["FlightType"].ToString(), Source = reader["Source"].ToString(), Destination = reader["Destination"].ToString(), TotalCost = (decimal)reader["TotalCost"] });
                }
            }

            return results;
        }

        public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
        {
            List<FlightHotelResult> results = new List<FlightHotelResult>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("sp_SearchFlightsWithHotels", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);
                command.Parameters.AddWithValue("@Persons", persons);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while(await reader.ReadAsync())
                {
                    results.Add(new FlightHotelResult() { FlightId = (int)reader["FlightId"], FlightName = reader["FlightName"].ToString(), Source = reader["Source"].ToString(), Destination = reader["Destination"].ToString(), HotelName = reader["HotelName"].ToString(), TotalCost = (decimal) reader["TotalCost"] });
                }


            }
            return results;
        }


    }
}
