using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Services;
using CourierManagementSystem.Interfaces;

namespace CourierManagementSystem.Dao
{
    public class CourierCustomerServiceImpl : ICourierCustomerInterface
    {
        public CourierCompany companyObj;

        public CourierCustomerServiceImpl(CourierCompany company)
        {
            companyObj = company;
        }

        public void PlaceOrder(Courier courier)
        {
            companyObj.CourierDetails.Add(courier);
        }

        public string GetOrderStatus(string trackingNumber)
        {
            var courier = companyObj.CourierDetails.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
            return courier != null ? courier.Status : "Courier not found.";
        }

        public void DeliverOrder(string trackingNumber)
        {
            var courier = companyObj.CourierDetails.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
            if (courier != null)
                courier.Status = "Delivered";
        }

        //Task 8(3)
        public void BookCourier(Courier courier)
        {
            companyObj.CourierDetails.Add(courier);
            Console.WriteLine("Courier booked successfully.");
        }
        public void TrackCourier(string trackingNumber)
        {
            var courier = companyObj.CourierDetails.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
            if (courier != null)
            {
                Console.WriteLine($"Status of courier {trackingNumber}: {courier.Status}");
            }
            else
            {
                Console.WriteLine("Courier not found.");
            }
        }

        public void ViewCouriersByCustomerId(string customerId)
        {
            var customerCouriers = companyObj.CourierDetails
                .Where(c => c.Customer != null && c.Customer.CustomerID == customerId)
                .ToList();

            if (customerCouriers.Any())
            {
                Console.WriteLine($"Couriers for customer {customerId}:");
                foreach (var courier in customerCouriers)
                {
                    Console.WriteLine($"Courier ID: {courier.CourierID}, Status: {courier.Status}");
                }
            }
            else
            {
                Console.WriteLine("No couriers found for this customer.");
            }
        }
    }
}
