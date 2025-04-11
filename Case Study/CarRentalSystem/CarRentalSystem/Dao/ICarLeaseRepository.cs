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
            void AddCustomer(Customer customer);
            void RemoveCustomer(int customerID);
            List<Customer> ListCustomers();
            Customer FindCustomerById(int customerID); 

            // Lease Management
            Lease CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate); 
            Lease ReturnVehicle(int leaseID); 
            List<Lease> ListActiveLeases(); 
            List<Lease> ListLeaseHistory(); 

            // Payment Handling
            void RecordPayment(Lease lease, double amount);
        }
}
