using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Util;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Entity;

namespace CarRentalSystem.Service
{
    public class VehicleService
    {
        public static void FindCar(int vehicleId)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Vehicle WHERE VehicleId = @VehicleId", connection);
            command.Parameters.AddWithValue("@VehicleId", vehicleId);

            int count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                throw new VehicleNotFoundException($"Car with ID {vehicleId} not found.");
            }

            Console.WriteLine("Car found!");
            connection.Close();
        }
        private readonly string _connectionString;

        public VehicleService(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void CreateCar(string make, string model)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Cars (Make, Model) VALUES (@make, @model)", conn);
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.ExecuteNonQuery();
            }

        }
    }
}