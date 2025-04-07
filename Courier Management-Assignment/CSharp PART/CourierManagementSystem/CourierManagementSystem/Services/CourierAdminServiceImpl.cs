using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Interfaces;
using CourierManagementSystem.Dao;

namespace CourierManagementSystem.Services
{
    public class CourierAdminServiceImpl : CourierCustomerServiceImpl, ICourierAdminInterface
    {
        public CourierAdminServiceImpl(CourierCompany company) : base(company)
        {
        }

        public void UpdateCourierStatus(string trackingNumber, string newStatus)
        {
            foreach (var courier in companyObj.CourierDetails)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    courier.Status = newStatus;
                    Console.WriteLine($"Status updated to {newStatus} for courier: {trackingNumber}");
                    return;
                }
            }
            Console.WriteLine("Courier not found.");
        }
        public void RemoveCourierByTrackingNumber(string trackingNumber)
        {
            var courierToRemove = companyObj.CourierDetails.Find(c => c.TrackingNumber == trackingNumber);
            if (courierToRemove != null)
            {
                companyObj.CourierDetails.Remove(courierToRemove);
                Console.WriteLine($"Courier with tracking number {trackingNumber} has been removed.");
            }
            else
            {
                Console.WriteLine("Courier not found.");
            }
        }
    }
}
