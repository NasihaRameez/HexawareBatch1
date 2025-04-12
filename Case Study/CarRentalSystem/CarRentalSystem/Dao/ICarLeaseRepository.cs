using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Entity;

namespace CarRentalSystem.Dao
{
        public interface ICarLeaseRepository
        {
        // Car Management
            void AddVehicle(Vehicle vehicle); 
            void RemoveVehicle(int vehicleID); 
            List<Vehicle> ListAvailableVehicles(); 
            List<Vehicle> ListRentedVehicles();
            Vehicle FindVehicleById(int vehicleID); 



        // Customer Management
            public void AddCustomer(Customer customer);
            public void RemoveCustomer(int customerID);
            List<Customer> ListCustomers();
            public Customer FindCustomerById(int customerID); 

            // Lease Management
            public Lease CreateLease(int customerID, int vehicleID, DateTime startDate, DateTime endDate, string type);
            public Lease GetLeaseById(int leaseID);
            public bool ReturnVehicle(int leaseID); 
            List<Lease> ListActiveLeases(); 
            List<Lease> ListLeaseHistory(); 

            // Payment Handling
            public void RecordPayment(int paymentID,Lease lease, double amount);
        }
}
