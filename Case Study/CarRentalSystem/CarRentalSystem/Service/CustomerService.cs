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
    public class CustomerService
    {
        public static void FindCustomer(int customerId)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Customer WHERE CustomerId = @CustomerId", connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            int count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
            }

            Console.WriteLine("Customer found!");
            connection.Close();
        }
    }
}