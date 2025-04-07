using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Interfaces;

namespace CourierManagementSystem.Services
{
    public class CourierCustomerService : ICourierCustomerInterface
    {
        private List<Courier> courierList = new List<Courier>();
        private CourierAdminService adminService = new CourierAdminService();

        //Task6
        //public string PlaceOrder(Courier courier)
        //{
        //    courierList.Add(courier);
        //    Console.WriteLine("Order placed successfully!");
        //    return courier.TrackingNumber;
        //}
        //public void GetOrderStatus(string trackingNumber)
        //{
        //    var c = courierList.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
        //    Console.WriteLine(c != null ? $"Status: {c.Status}" : "Tracking number not found.");
        //}

        //public void CancelOrder(string trackingNumber)
        //{
        //    var c = courierList.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
        //    if (c != null && c.Status != "Delivered")
        //    {
        //        c.Status = "Cancelled";
        //        Console.WriteLine("Order cancelled successfully.");
        //    }
        //    else
        //        Console.WriteLine("Order cannot be cancelled.");
        //}

        //public void GetAssignedOrder(int staffID)
        //{
        //    var orders = courierList.Where(c => c.CourierStaffID == staffID).ToList();
        //    if (orders.Any())
        //        orders.ForEach(o => Console.WriteLine(o));
        //    else
        //        Console.WriteLine("No orders for this staff.");
        //}

        //Task7
        //public string GetOrderStatus(string trackingNumber)
        //{
        //    var order = courierList.Find(c => c.TrackingNumber == trackingNumber);
        //    if (order == null)
        //    {
        //        throw new TrackingNumberNotFoundException("Tracking number not found: " + trackingNumber);
        //    }
        //    return order.Status;
        //}

        //public bool CancelOrder(string trackingNumber)
        //{
        //    var order = courierList.Find(c => c.TrackingNumber == trackingNumber);
        //    if (order == null)
        //    {
        //        throw new TrackingNumberNotFoundException("Cannot cancel. Tracking number not found: " + trackingNumber);
        //    }
        //    courierList.Remove(order);
        //    return true;
        //}

        //public string PlaceOrder(Courier courier)
        //{
        //    if (!adminService.IsValidEmployee(courier.CourierStaffID))
        //    {
        //        throw new InvalidEmployeeIdException("Invalid Courier Staff ID.");
        //    }

        //    courierList.Add(courier);
        //    return courier.TrackingNumber;
        //}



    }
}


