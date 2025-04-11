using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Entity;

namespace CarRentalSystem.Dao
{
    public class ICarLeaseRepositoryImpl : ICarLeaseRepository
    {
        // In-memory list for demo purposes. Replace with actual database interactions.
        private List<Vehicle> vehicles = new List<Vehicle>();
        private List<Customer> customers = new List<Customer>();
        private List<Lease> leases = new List<Lease>();

        // Car Management
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void RemoveVehicle(int vehicleID)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleID == vehicleID);
            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
            }
            else
            {
                throw new Exception("Vehicle not found!");
            }
        }

        public List<Vehicle> ListAvailableVehicles()
        {
            return vehicles.Where(v => v.Status == "Available").ToList();
        }

        public List<Vehicle> ListRentedVehicles()
        {
            return vehicles.Where(v => v.Status == "Rented").ToList();
        }

        public Vehicle FindVehicleById(int vehicleID)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleID == vehicleID);
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found!");
            }
            return vehicle;
        }

        // Customer Management
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer); 
        }

        public void RemoveCustomer(int customerID)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == customerID);
            if (customer != null)
            {
                customers.Remove(customer);
            }
            else
            {
                throw new Exception("Customer not found!");
            }
        }

        public List<Customer> ListCustomers()
        {
            return customers;  
        }

        public Customer FindCustomerById(int customerID)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == customerID);
            if (customer == null)
            {
                throw new Exception("Customer not found!");
            }
            return customer;
        }

        // Lease Management
        public Lease CreateLease(int customerID, int vehicleID, DateTime startDate, DateTime endDate)
        {
            var customer = FindCustomerById(customerID);  
            var vehicle = FindVehicleById(vehicleID);  

            if (vehicle.Status == "Rented")
            {
                throw new Exception("Vehicle is already rented.");
            }

            Lease lease = new Lease
            {
                LeaseID = leases.Count + 1,  
                CustomerID = customerID,
                VehicleID = vehicleID,
                StartDate = startDate,
                EndDate = endDate
            };

            leases.Add(lease);
            vehicle.Status = "Rented";  
            return lease;
        }

        public Lease ReturnVehicle(int leaseID)
        {
            var lease = leases.FirstOrDefault(l => l.LeaseID == leaseID);
            if (lease == null)
            {
                throw new Exception("Lease not found.");
            }
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleID == lease.VehicleID);  
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found.");
            }

            vehicle.Status = "Available";   
            return lease;
        }

        public List<Lease> ListActiveLeases()
        {
            return leases.Where(l => l.EndDate >= DateTime.Now).ToList();
        }

        public List<Lease> ListLeaseHistory()
        {
            return leases;  
        }

        // Payment Handling
        public void RecordPayment(Lease lease, double amount)
        {
            Console.WriteLine($"Payment of {amount} recorded for LeaseID {lease.LeaseID}");
            
        }
    }
}