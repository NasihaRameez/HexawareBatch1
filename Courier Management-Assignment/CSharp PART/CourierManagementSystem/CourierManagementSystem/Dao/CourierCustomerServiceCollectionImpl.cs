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
    public class CourierCustomerServiceCollectionImpl : ICourierCustomerInterface
    {
        private CourierCompanyCollection companyObj;

        public CourierCustomerServiceCollectionImpl()
        {
            companyObj = new CourierCompanyCollection();
        }

        public void AddCourierCompany(CourierCompany company)
        {
            companyObj.AddCompany(company);
        }

        public List<CourierCompany> GetAllCourierCompanies()
        {
            return companyObj.GetAllCompanies();
        }

        //Task 8
        //3.

        protected CourierCompanyCollection companyObj;

        public CourierCustomerServiceCollectionImpl(CourierCompanyCollection company)
        {
            this.companyObj = company;
        }

        public void BookCourier(Courier courier)
        {
            companyObj.Couriers.Add(courier);
            Console.WriteLine($"Courier booked successfully with tracking number: {courier.TrackingNumber}");
        }

        public void TrackCourier(string trackingNumber)
        {
            var courier = companyObj.Couriers.Find(c => c.TrackingNumber == trackingNumber);
            if (courier != null)
                Console.WriteLine($"Courier found. Status: {courier.Status}");
            else
                Console.WriteLine("Courier not found.");
        }

        public void ViewCouriersByCustomerId(string customerId)
        {
            var customerCouriers = companyObj.Couriers.FindAll(c => c.Customer.CustomerID == customerId);
            if (customerCouriers.Count == 0)
            {
                Console.WriteLine("No couriers found for this customer.");
            }
            else
            {
                foreach (var courier in customerCouriers)
                {
                    Console.WriteLine($"Tracking Number: {courier.TrackingNumber}, Status: {courier.Status}");
                }
            }
        }
    }
}


