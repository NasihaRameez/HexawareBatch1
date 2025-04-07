using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Interfaces
{
    public interface ICourierCustomerInterface
    {
        //string PlaceOrder(Courier courier);
        //string GetOrderStatus(string trackingNumber);
        //bool CancelOrder(string trackingNumber);
        //void GetAssignedOrder(int courierStaffID);
        //void AddCourierCompany(CourierCompany company);
        //List<CourierCompany> GetAllCourierCompanies();
        //void PlaceOrder(Courier courier);
        //string GetOrderStatus(string trackingNumber);
        //void DeliverOrder(string trackingNumber);
        void BookCourier(Courier courier);
        void TrackCourier(string trackingNumber);
        void ViewCouriersByCustomerId(string customerId);
    }
}
