using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Interfaces;

namespace CourierManagementSystem.Dao
{
    public class CourierAdminServiceCollectionImpl : CourierCustomerServiceCollectionImpl, ICourierAdminInterface
    {
        public CourierAdminServiceCollectionImpl(CourierCompanyCollection company) : base(company)
        {
        }

        public void UpdateCourierStatus(string trackingNumber, string newStatus)
        {
            foreach (var courier in companyObj.Couriers)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    courier.Status = newStatus;
                    Console.WriteLine($"Status updated to {newStatus} for courier {trackingNumber}");
                    return;
                }
            }
            Console.WriteLine("Courier not found.");
        }

        public void RemoveCourierByTrackingNumber(string trackingNumber)
        {
            var courierToRemove = companyObj.Couriers.Find(c => c.TrackingNumber == trackingNumber);
            if (courierToRemove != null)
            {
                companyObj.Couriers.Remove(courierToRemove);
                Console.WriteLine($"Courier with tracking number {trackingNumber} removed.");
            }
            else
            {
                Console.WriteLine("Courier not found.");
            }
        }
    }
}