using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Dao;
using CarRentalSystem.Entity;
using NUnit.Framework;
using System.Data.SqlClient;

namespace CarRentalSystem.Tests
{
    [TestFixture]
    public class CarLeaseTests
    {
        private ICarLeaseRepositoryImpl _repo;
        private int _testLeaseId;

        [SetUp]
        public void Setup()
        {
            _repo = new ICarLeaseRepositoryImpl();
            AddTestData();
        }
        private void AddTestData()
        {
            int testCustomerId = 11;
            int testVehicleId = 6;

            var existingCustomer = _repo.FindCustomerById(testCustomerId);
            if (existingCustomer == null)
            {
                var customer = new Customer
                {
                    CustomerID = testCustomerId,
                    FirstName = "John",
                    LastName = "Dowy",
                    Email = "john.dowy@email.com",
                    PhoneNumber = "1234567899"
                };
                _repo.AddCustomer(customer);
            }

            // Check if vehicle already exists
            var existingVehicle = _repo.FindVehicleById(testVehicleId);
            if (existingVehicle == null)
            {
                var vehicle = new Vehicle
                {
                    VehicleID = testVehicleId,
                    Make = "Hyundai",
                    Model = "Creta",
                    Year = 2024,
                    DailyRate = 600,
                    Status = "Available",
                    PassengerCapacity = 5,
                    EngineCapacity = 6                };
                _repo.AddVehicle(vehicle);
            }

           var lease = _repo.CreateLease(testCustomerId, testVehicleId,
                                              new DateTime(2025, 05, 01),
                                              new DateTime(2025, 05, 05),
                                              "DailyLease");

            _testLeaseId = lease.LeaseID;
        }

        [Test]
        public void Test_CreateLease_CreatesLeaseSuccessfully()
        {
            int customerId = 11;  
            int vehicleId = 6;  

            var lease = _repo.CreateLease(customerId, vehicleId,
                                          new DateTime(2025, 05, 06),
                                          new DateTime(2025, 05, 10),
                                          "DailyLease");

            Assert.That(lease, Is.Not.Null);
            Assert.That(lease.CustomerID, Is.EqualTo(customerId)); 
            Assert.That(lease.VehicleID, Is.EqualTo(vehicleId));  
        }

        [Test]
        public void Test_GetLeaseById_ReturnsCorrectLease()
        {
            
            var lease = _repo.GetLeaseById(_testLeaseId);

            Assert.That(lease, Is.Not.Null);
            Assert.That(lease.LeaseID, Is.EqualTo(_testLeaseId));
            Assert.That(lease.Type, Is.EqualTo("DailyLease"));
        }

        [Test]
        public void Test_CreateLease_ThrowsException_WhenCustomerNotFound()
        {
            int invalidCustomerId = 999; // Does not exist
            int validVehicleId = 6;

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _repo.CreateLease(invalidCustomerId, validVehicleId,
                    new DateTime(2025, 05, 11), new DateTime(2025, 05, 13), "DailyLease");
            });

            Assert.That(ex.Message, Does.Contain("Customer with ID"));
        }


        [Test]
        public void Test_CreateLease_ThrowsException_WhenVehicleNotFound()
        {
            int validCustomerId = 11;
            int invalidVehicleId = 999; // Does not exist

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                _repo.CreateLease(validCustomerId, invalidVehicleId,
                    new DateTime(2025, 05, 14), new DateTime(2025, 05, 15), "DailyLease");
            });

            Assert.That(ex.Message, Does.Contain("Vehicle with ID"));

        }

        [Test]
        public void Test_GetLeaseById_ThrowsException_WhenLeaseNotFound()
        {
            int invalidLeaseId = 999;

            var ex = Assert.Throws<Exception>(() =>
            {
                var lease = _repo.GetLeaseById(invalidLeaseId);
            });

            Assert.That(ex.Message, Does.Contain("Lease not found"));
        }
    }
}
