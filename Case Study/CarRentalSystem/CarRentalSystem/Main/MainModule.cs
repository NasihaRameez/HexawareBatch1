using System.Data.SqlClient;
using CarRentalSystem.Util;
using System.IO;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Service;

namespace CarRentalSystem.Main
{
    internal class MainModule
    {
        static void Main(string[] args)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            Console.WriteLine("Connection Successful!");
            connection.Close();

            //Task 9
            try
            {
                Console.WriteLine("Enter Car ID to search: ");
                int vehicleId = Convert.ToInt32(Console.ReadLine());
                VehicleService.FindCar(vehicleId);

                Console.WriteLine("Enter Lease ID to search: ");
                int leaseId = Convert.ToInt32(Console.ReadLine());
                LeaseService.FindLease(leaseId);

                Console.WriteLine("Enter Customer ID to search: ");
                int customerId = Convert.ToInt32(Console.ReadLine());
                CustomerService.FindCustomer(customerId);
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
