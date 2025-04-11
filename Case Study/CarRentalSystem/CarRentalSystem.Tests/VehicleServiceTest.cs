using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using CarRentalSystem.Service;
using CarRentalSystem.Entity;
using CarRentalSystem.Exceptions;
using NUnit.Framework;
using System.Data.SqlClient;
using CarRentalSystem.Util;

namespace CarRentalSystem.Tests
{
    [TestFixture]

    public class VehicleServiceTest
    {
        private VehicleService _vehicleService;
        public void Setup()
        {
            _vehicleService = new VehicleService(); 
        }
        [Test]
        public void TestCarCreatedSuccessfully()
        {
            var VehicleService = new VehicleService();

            var result = VehicleService.CreateCar("Maruti Suzuki", "Swift");

            ClassicAssert.IsTrue(result);
        }
    }
}


