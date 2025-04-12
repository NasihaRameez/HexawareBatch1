using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Util;
using CarRentalSystem.Entity;

namespace CarRentalSystem.Service
{
    public class LeaseService
    {
        public static bool FindLease(int leaseId)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Lease WHERE LeaseId = @LeaseId", connection);
            command.Parameters.AddWithValue("@LeaseId", leaseId);

            int count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                throw new LeaseNotFoundException($"Lease with ID {leaseId} not found.");
            }

            Console.WriteLine("Lease found!");
            connection.Close();
            return count > 0;
        }
    }
}
