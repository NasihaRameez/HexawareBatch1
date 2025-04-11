using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Service;
using CarRentalSystem.Entity;
using NUnit.Framework;
using System.Data.SqlClient;
using CarRentalSystem.Util;

namespace CarRentalSystem.Tests
{

    public class ExceptionTest
    {
        [Test]
        public void TestCarNotFoundExceptionThrown()
        {
            var vehicleService = new VehicleService();
            var invalidvehicleId = 999;

            var ex = Assert.Throws<VehicleNotFoundException>(() => VehicleService.FindCar(invalidvehicleId));
            ClassicAssert.AreEqual("Car not found!", ex.Message); 
        }

        [Test]
        public void TestLeaseNotFoundExceptionThrown()
        {
            var leaseService = new LeaseService();
            var invalidLeaseId = 999; 

            var ex =Assert.Throws<LeaseNotFoundException>(() => LeaseService.FindLease(invalidLeaseId));
            ClassicAssert.AreEqual("Lease not found!", ex.Message); 
        }

        [Test]
        public void TestCustomerNotFoundExceptionThrown()
        {
            var customerService = new CustomerService();
            var invalidCustomerId = 999; 

            var ex = ClassicAssert.Throws<CustomerNotFoundException>(() => CustomerService.FindCustomer(invalidCustomerId));
            ClassicAssert.AreEqual("Customer not found!", ex.Message); 
        }
    }
}
