using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Util;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Entity;
using System.Runtime.ConstrainedExecution;

namespace CarRentalSystem.Service
{
    public class VehicleService
    {
        public static void FindCarByID(int vehicleId)
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

       
    }
}
       
        
       