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
   

    public class LeaseServiceTest
    {
        [Test]
        public void TestLeaseCreatedSuccessfully()
        {
            var leaseService = new LeaseService();

            var result = LeaseService.CreateLease(21, 22, DateTime.Now, DateTime.Now.AddDays(7), 5000);

            ClassicAssert.IsTrue(result);
        }
        [Test]
        public void TestLeaseRetrievedSuccessfully()
        {
            var leaseService = new LeaseService();

            bool lease = LeaseService.FindLease(12); 

            ClassicAssert.IsNotNull(lease); 
        }
    }
}
