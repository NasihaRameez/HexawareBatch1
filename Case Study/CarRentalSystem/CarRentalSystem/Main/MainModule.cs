using System.Data.SqlClient;
using CarRentalSystem.Util;
using System.IO;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Service;
using CarRentalSystem.Dao;
using CarRentalSystem.Entity;


namespace CarRentalSystem.Main
{
    internal class MainModule
    {
        static ICarLeaseRepositoryImpl carLeaseRepo = new ICarLeaseRepositoryImpl();
        static void Main(string[] args)
        {
            SqlConnection connection = DBConnection.GetConnection();
            connection.Open();
            Console.WriteLine("Connection Successful!");
            connection.Close();

            bool continueApp = true;
            while (continueApp)
            {
                Console.Clear();
                Console.WriteLine("Connection Successful!");
                Console.WriteLine("--Car Rental System--");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                Console.WriteLine("3. List Available Vehicles");
                Console.WriteLine("4. List Rented Vehicles");
                Console.WriteLine("5. Add Customer");
                Console.WriteLine("6. Remove Customer");
                Console.WriteLine("7. List Customers");
                Console.WriteLine("8. Create Lease");
                Console.WriteLine("9. Return Vehicle");
                Console.WriteLine("10. List Active Leases");
                Console.WriteLine("11. List Lease History");
                Console.WriteLine("12. Record Payment");
                Console.WriteLine("13. Exit");
                Console.Write("Choose an option (1-13): ");
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        AddVehicle();
                        break;
                    case "2":
                        RemoveVehicle();
                        break;
                    case "3":
                        ListAvailableVehicles();
                        break;
                    case "4":
                        ListRentedVehicles();
                        break;
                    case "5":
                        AddCustomer();
                        break;
                    case "6":
                        RemoveCustomer();
                        break;
                    case "7":
                        ListCustomers();
                        break;
                    case "8":
                        CreateLease();
                        break;
                    case "9":
                        ReturnVehicle();
                        break;
                    case "10":
                        ListActiveLeases();
                        break;
                    case "11":
                        ListLeaseHistory();
                        break;
                    case "12":
                        RecordPayment();
                        break;
                    case "13":
                        continueApp = false;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void AddVehicle()
        {
            Console.WriteLine("Enter Vehicle Details");

            Console.Write("Vehicle ID: ");
            int vehicleID = int.Parse(Console.ReadLine());

            Console.Write("Make: ");
            string make = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Daily Rate: ");
            decimal dailyRate = decimal.Parse(Console.ReadLine());

            Console.Write("Status (Available/NotAvailable): ");
            string status = Console.ReadLine();

            Console.Write("Passenger Capacity: ");
            int passengerCapacity = int.Parse(Console.ReadLine());

            Console.Write("Engine Capacity: ");
            int engineCapacity = int.Parse(Console.ReadLine());

            Vehicle newVehicle = new Vehicle
            {
                VehicleID = vehicleID,
                Make = make,
                Model = model,
                Year = year,
                DailyRate = dailyRate,
                Status = status,
                PassengerCapacity = passengerCapacity,
                EngineCapacity = engineCapacity
            };

            carLeaseRepo.AddVehicle(newVehicle);
            Console.WriteLine("Vehicle added successfully.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void RemoveVehicle()
        {
            Console.Write("Enter Vehicle ID to remove: ");
            int vehicleID = int.Parse(Console.ReadLine());
            carLeaseRepo.RemoveVehicle(vehicleID);
            Console.WriteLine("Vehicle removed successfully.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void ListAvailableVehicles()
        {
            List<Vehicle> availableVehicles = carLeaseRepo.ListAvailableVehicles();
            if (availableVehicles.Count == 0)
            {
                Console.WriteLine("No available vehicles.");
            }
            else
            {
                Console.WriteLine("Available Vehicles:");
                foreach (var vehicle in availableVehicles)
                {
                    Console.WriteLine($"ID: {vehicle.VehicleID}, Make: {vehicle.Make}, Model: {vehicle.Model}, Year: {vehicle.Year}, Daily Rate: {vehicle.DailyRate}, Status: {vehicle.Status}, Passenger Capacity: {vehicle.PassengerCapacity}, Engine Capacity: {vehicle.EngineCapacity}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void ListRentedVehicles()
        {
            List<Vehicle> rentedVehicles = carLeaseRepo.ListRentedVehicles();
            if (rentedVehicles.Count == 0)
            {
                Console.WriteLine("No rented vehicles.");
            }
            else
            {
                Console.WriteLine("Rented Vehicles:");
                foreach (var vehicle in rentedVehicles)
                {
                    Console.WriteLine($"ID: {vehicle.VehicleID}, Make: {vehicle.Make}, Model: {vehicle.Model}, Year: {vehicle.Year}, Daily Rate: {vehicle.DailyRate}, Status: {vehicle.Status}, Passenger Capacity: {vehicle.PassengerCapacity}, Engine Capacity: {vehicle.EngineCapacity}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void AddCustomer()
        {
            Console.WriteLine("Enter Customer Details");

            Console.Write("Customer ID: ");
            int customerID = int.Parse(Console.ReadLine());

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Customer newCustomer = new Customer
            {
                CustomerID = customerID,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            carLeaseRepo.AddCustomer(newCustomer);
            Console.WriteLine("Customer added successfully.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        // Method to remove a customer
        static void RemoveCustomer()
        {
            Console.Write("Enter Customer ID to remove: ");
            int customerID = int.Parse(Console.ReadLine());
            carLeaseRepo.RemoveCustomer(customerID);
            Console.WriteLine("Customer removed successfully.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void ListCustomers()
        {
            List<Customer> customers = carLeaseRepo.ListCustomers();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
            }
            else
            {
                Console.WriteLine("Customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.CustomerID}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void CreateLease()
        {
            Console.Write("Enter Customer ID: ");
            int customerID = int.Parse(Console.ReadLine());

            Console.Write("Enter Vehicle ID: ");
            int vehicleID = int.Parse(Console.ReadLine());

            Console.Write("Enter Lease Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Lease End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Lease Type (DailyLease/MonthlyLease): ");
            string type = Console.ReadLine();

            Lease newLease = carLeaseRepo.CreateLease(customerID, vehicleID, startDate, endDate, type);
            Console.WriteLine("Lease created successfully. Lease ID: " + newLease.LeaseID);
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        // Method to return a vehicle
        static void ReturnVehicle()
        {
            Console.Write("Enter Lease ID to return vehicle: ");
            int leaseID = int.Parse(Console.ReadLine());

            bool result = carLeaseRepo.ReturnVehicle(leaseID);
            if (result)
            {
                Console.WriteLine("Vehicle returned successfully.");
            }
            else
            {
                Console.WriteLine("Failed to return vehicle.");
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void ListActiveLeases()
        {
            List<Lease> activeLeases = carLeaseRepo.ListActiveLeases();
            if (activeLeases.Count == 0)
            {
                Console.WriteLine("No active leases.");
            }
            else
            {
                Console.WriteLine("Active Leases:");
                foreach (var lease in activeLeases)
                {
                    Console.WriteLine($"Lease ID: {lease.LeaseID}, Customer ID: {lease.CustomerID}, Vehicle ID: {lease.VehicleID}, Start: {lease.StartDate}, End: {lease.EndDate}, Type: {lease.Type}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void ListLeaseHistory()
        {
            List<Lease> leaseHistory = carLeaseRepo.ListLeaseHistory();
            if (leaseHistory.Count == 0)
            {
                Console.WriteLine("No lease history available.");
            }
            else
            {
                Console.WriteLine("Lease History:");
                foreach (var lease in leaseHistory)
                {
                    Console.WriteLine($"Lease ID: {lease.LeaseID}, Customer ID: {lease.CustomerID}, Vehicle ID: {lease.VehicleID}, Start: {lease.StartDate}, End: {lease.EndDate}, Type: {lease.Type}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
        static void RecordPayment()
        {
            Console.Write("Enter Payment ID: ");
            int paymentID = int.Parse(Console.ReadLine());

            Console.Write("Enter Lease ID: ");
            int leaseID = int.Parse(Console.ReadLine());

            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());

            // Retrieve lease object from DB
            Lease lease = carLeaseRepo.GetLeaseById(leaseID);
            if (lease == null)
            {
                Console.WriteLine("Lease not found.");
                return;
            }

            // Record the payment
            carLeaseRepo.RecordPayment(paymentID, lease, amount);
            Console.WriteLine("Payment recorded successfully.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }


        //Task 9
        //    try
        //    {
        //        Console.WriteLine("Enter Car ID to search: ");
        //        int vehicleId = Convert.ToInt32(Console.ReadLine());
        //        VehicleService.FindCarByID(vehicleId);
        //    }
        //    catch (VehicleNotFoundException ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }


        //    try
        //    {
        //       Console.WriteLine("Enter Lease ID to search: ");
        //       int leaseId = Convert.ToInt32(Console.ReadLine());
        //       LeaseService.FindLease(leaseId);
        //    }

        //    catch (LeaseNotFoundException ex)
        //    {
        //      Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    try
        //    {
        //       Console.WriteLine("Enter Customer ID to search: ");
        //       int customerId = Convert.ToInt32(Console.ReadLine());
        //       CustomerService.FindCustomer(customerId);
        //    }
        //    catch (CustomerNotFoundException ex)
        //    {
        //       Console.WriteLine($"Error: {ex.Message}");
        //    }

        //   // Catch any other unexpected errors
        //    catch (Exception ex)
        //    {
        //      Console.WriteLine($"Unexpected error: {ex.Message}");
        //    }
    }
}
