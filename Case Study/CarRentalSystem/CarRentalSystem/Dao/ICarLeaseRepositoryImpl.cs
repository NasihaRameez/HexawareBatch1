using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Entity;

namespace CarRentalSystem.Dao
{
    public class ICarLeaseRepositoryImpl : ICarLeaseRepository
    {
        public string connectionString = "Data Source=DESKTOP-AUT68C9\\SQLEXPRESS;Initial Catalog=CarRentaldb;Integrated Security=True";

        // Car Management
        public void AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Vehicle 
                         (vehicleID, make, model, year, dailyrate, status, passengercapacity, enginecapacity) 
                         VALUES 
                         (@VehicleID, @Make, @Model, @Year, @DailyRate, @Status, @PassengerCapacity, @EngineCapacity)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);
                cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                cmd.Parameters.AddWithValue("@PassengerCapacity", vehicle.PassengerCapacity);
                cmd.Parameters.AddWithValue("@EngineCapacity", vehicle.EngineCapacity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveVehicle(int vehicleID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Vehicle not found or already removed.");
                }
            }
        }

        public List<Vehicle> ListAvailableVehicles()
        {
            List<Vehicle> availableVehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicle WHERE Status = 'Available'";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    availableVehicles.Add(new Vehicle
                    {
                        VehicleID = (int)reader["vehicleID"],
                        Make = reader["make"].ToString(),
                        Model = reader["model"].ToString(),
                        Year = Convert.ToInt32(reader["year"]),
                        DailyRate = Convert.ToDecimal(reader["dailyrate"]),
                        Status = reader["status"].ToString(),
                        PassengerCapacity = Convert.ToInt32(reader["passengercapacity"]),
                        EngineCapacity = Convert.ToInt32(reader["enginecapacity"])
                    });
                }
            }

            return availableVehicles;
        }

        public List<Vehicle> ListRentedVehicles()
        {
            List<Vehicle> rentedVehicles = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicle WHERE Status = 'NotAvailable'";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rentedVehicles.Add(new Vehicle
                    {
                        VehicleID = (int)reader["vehicleID"],
                        Make = reader["make"].ToString(),
                        Model = reader["model"].ToString(),
                        Year = (int)reader["year"],
                        DailyRate = Convert.ToDecimal(reader["dailyrate"]),
                        Status = reader["status"].ToString(),
                        PassengerCapacity = Convert.ToInt32(reader["passengercapacity"]),
                        EngineCapacity = Convert.ToInt32(reader["enginecapacity"])
                    });
                }
            }

            return rentedVehicles;
        }

        public Vehicle FindVehicleById(int vehicleID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Vehicle
                    {
                        VehicleID = (int)reader["vehicleID"],
                        Make = reader["make"].ToString(),
                        Model = reader["model"].ToString(),
                        Year = (int)reader["year"],
                        DailyRate = Convert.ToDecimal(reader["dailyrate"]),
                        Status = reader["status"].ToString(),
                        PassengerCapacity = Convert.ToInt32(reader["passengercapacity"]),
                        EngineCapacity = Convert.ToInt32(reader["enginecapacity"])
                    };
                }
                else
                {
                    throw new Exception($"Vehicle with ID {vehicleID} not found.");
                }
            }
        }

        // Customer Management
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Customer (customerID, firstName, lastName, email, phoneNumber) 
                         VALUES (@CustomerID, @FirstName, @LastName, @Email, @PhoneNumber)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveCustomer(int customerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString()
                    });
                }
            }

            return customers;
        }

        public Customer FindCustomerById(int customerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerID = Convert.ToInt32(reader["customerID"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Email = reader["email"].ToString(),
                        PhoneNumber = reader["phoneNumber"].ToString()
                    };
                }
                else
                {
                    throw new Exception("Customer not found with ID: " + customerID);
                }
            }
        }

        // Lease Management
        public Lease CreateLease(int customerID, int vehicleID, DateTime startDate, DateTime endDate, string type)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("End date must be after the start date.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Check if the customer exists
                string customerCheckQuery = "SELECT COUNT(*) FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand customerCheckCmd = new SqlCommand(customerCheckQuery, conn);
                customerCheckCmd.Parameters.AddWithValue("@CustomerID", customerID);

                int customerCount = (int)customerCheckCmd.ExecuteScalar();
                if (customerCount == 0)
                {
                    throw new InvalidOperationException("Customer with ID " + customerID + " does not exist.");
                }
                // Check if the vehicle exists
                string vehicleCheckQuery = "SELECT COUNT(*) FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand vehicleCheckCmd = new SqlCommand(vehicleCheckQuery, conn);
                vehicleCheckCmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                int vehicleCount = (int)vehicleCheckCmd.ExecuteScalar();
                if (vehicleCount == 0)
                {
                    throw new InvalidOperationException("Vehicle with ID " + vehicleID + " does not exist.");
                }

                // Check for existing lease
                string checkQuery = @"SELECT COUNT(*) FROM Lease 
                              WHERE VehicleID = @VehicleID 
                              AND (
                                  (@StartDate BETWEEN startDate AND endDate) OR
                                  (@EndDate BETWEEN startDate AND endDate) OR
                                  (startDate BETWEEN @StartDate AND @EndDate)
                              )";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                checkCmd.Parameters.AddWithValue("@StartDate", startDate);
                checkCmd.Parameters.AddWithValue("@EndDate", endDate);

                int conflictCount = (int)checkCmd.ExecuteScalar();
                //if (conflictCount > 0)
                //{
                //    throw new InvalidOperationException("Vehicle is already leased for the selected date range.");
                //}
                string leaseIdQuery = "SELECT MAX(LeaseID) FROM Lease";
                SqlCommand leaseIdCmd = new SqlCommand(leaseIdQuery, conn);
                object result = leaseIdCmd.ExecuteScalar();
                int newLeaseID = result == DBNull.Value ? 1 : (int)result + 1;

                // Insert new lease
                string insertQuery = @"INSERT INTO Lease (leaseID, vehicleID, customerID, startDate, endDate, type) 
                               VALUES (@LeaseID,@VehicleID, @CustomerID, @StartDate, @EndDate, @Type);
                               SELECT SCOPE_IDENTITY();";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@LeaseID", newLeaseID);
                insertCmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                insertCmd.Parameters.AddWithValue("@CustomerID", customerID);
                insertCmd.Parameters.AddWithValue("@StartDate", startDate);
                insertCmd.Parameters.AddWithValue("@EndDate", endDate);
                insertCmd.Parameters.AddWithValue("@Type", type);

                insertCmd.ExecuteNonQuery();

                return new Lease
                {
                    LeaseID = newLeaseID,
                    VehicleID = vehicleID,
                    CustomerID = customerID,
                    StartDate = startDate,
                    EndDate = endDate,
                    Type = type
                };
            }
        }

        public Lease GetLeaseById(int leaseID)
        {
            Lease lease = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Lease WHERE LeaseID = @LeaseID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LeaseID", leaseID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lease = new Lease
                    {
                        LeaseID = (int)reader["leaseID"],
                        VehicleID = (int)reader["vehicleID"],
                        CustomerID = (int)reader["customerID"],
                        StartDate = (DateTime)reader["startDate"],
                        EndDate = (DateTime)reader["endDate"],
                        Type = reader["type"].ToString() // 'DailyLease' or 'MonthlyLease'
                    };
                }
                if (lease == null)
                    throw new Exception("Lease not found with ID: " + leaseID);

            }

            return lease;
        }


        public bool ReturnVehicle(int leaseID)
        {
            // Step 1: Check if the lease exists
            Lease lease = GetLeaseById(leaseID);
            if (lease == null)
            {
                throw new InvalidOperationException("Lease not found.");
            }

            // Step 2: Update vehicle status to 'Available'
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Vehicle 
                         SET Status = 'Available' 
                         WHERE VehicleID = @VehicleID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleID", lease.VehicleID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true; // Vehicle returned successfully
                }
                else
                {
                    throw new InvalidOperationException("Failed to update vehicle status.");
                }
            }
        }

        public List<Lease> ListActiveLeases()
        {
            List<Lease> leases = new List<Lease>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Lease 
                         WHERE GETDATE() BETWEEN startDate AND endDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    leases.Add(new Lease
                    {
                        LeaseID = (int)reader["leaseID"],
                        VehicleID = (int)reader["vehicleID"],
                        CustomerID = (int)reader["customerID"],
                        StartDate = Convert.ToDateTime(reader["startDate"]),
                        EndDate = Convert.ToDateTime(reader["endDate"]),
                        Type = reader["type"].ToString()
                    });
                }
            }

            return leases;
        }

        public List<Lease> ListLeaseHistory()
        {
            List<Lease> leases = new List<Lease>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Lease";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    leases.Add(new Lease
                    {
                        LeaseID = (int)reader["leaseID"],
                        VehicleID = (int)reader["vehicleID"],
                        CustomerID = (int)reader["customerID"],
                        StartDate = Convert.ToDateTime(reader["startDate"]),
                        EndDate = Convert.ToDateTime(reader["endDate"]),
                        Type = reader["type"].ToString()
                    });
                }
            }

            return leases;
        }

        // Payment Handling
        public void RecordPayment(int paymentID, Lease lease, double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Payment (paymentID, leaseID, paymentDate, amount)
                         VALUES (@PaymentID, @LeaseID, @PaymentDate, @Amount)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                cmd.Parameters.AddWithValue("@LeaseID", lease.LeaseID);
                cmd.Parameters.AddWithValue("@PaymentDate", lease.EndDate);
                cmd.Parameters.AddWithValue("@Amount", amount);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}