using System;
using CourierManagementSystem;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Services;
using System.Collections.Generic;
using CourierManagementSystem.Dao;
using CourierManagementSystem.Interfaces;
using CourierManagementSystem.Util;
class MainModule
{
    //Task 6
    static void Main()
    {
        // Customer Service 
        //var userService = new CourierCustomerService();
        //var adminService = new CourierAdminService();
        //CourierCompanyCollection companyCollection = new CourierCompanyCollection();
        //CourierCustomerServiceCollectionImpl service = new CourierCustomerServiceCollectionImpl();
        //CourierCompany company = new CourierCompany();
        //ICourierCustomerInterface userService = new CourierCustomerServiceImpl(company);

        //var courier = new Courier
        //{
        //    CourierID = 1,
        //    TrackingNumber = "TN2025N001",
        //    SenderName = "James",
        //    SenderAddress = "Puducherry",
        //    ReceiverName = "Shyla",
        //    ReceiverAddress = "Chennai",
        //    Weight = 1.5,
        //    Status = "In Transit",
        //    CourierStaffID = 101,
        //    CustomerID = 11,
        //    DeliveryDate = DateTime.Now.AddDays(2)
        //};

        //userService.PlaceOrder(courier);

        //userService.GetOrderStatus("TN2025N001");

        //userService.CancelOrder("TN2025N001");

        //userService.GetAssignedOrder(101);

        // Admin Service 

        //var adminService = new CourierAdminService();

        //var staff = new Employee
        //{
        //    EmployeeName = "John Downy",
        //    ContactNumber = "9876543210"
        //};

        //int staffId = adminService.AddCourierStaff(staff);
        //Console.WriteLine("New staff ID: " + staffId);

        //Task 7
        //try
        //{
        //    string status = userService.GetOrderStatus("TN2025N999");
        //    Console.WriteLine("Order Status: " + status);
        //}
        //catch (TrackingNumberNotFoundException ex)
        //{
        //    Console.WriteLine("Custom Exception Caught: " + ex.Message);
        //}
        //finally
        //{
        //    Console.WriteLine("Checked for order status.");
        //}
        //try
        //{
        //    var courier = new Courier
        //    {
        //        TrackingNumber = "TN2025N002",
        //        SenderName = "Jenny",
        //        SenderAddress = "Puducherry",
        //        ReceiverName = "Rosy",
        //        ReceiverAddress = "Chennai",
        //        Weight = 1.2,
        //        Status = "In Transit",
        //        CourierStaffID = 999,
        //        CustomerID = 3
        //    };

        //    userService.PlaceOrder(courier);
        //}
        //catch (InvalidEmployeeIdException ex)
        //{
        //    Console.WriteLine("Custom Exception Caught: " + ex.Message);
        //}
        //finally
        //{
        //    Console.WriteLine("Attempted to place courier order.");
        //}

        //Task 8
        //1
        //Location location1 = new Location { LocationID = 1, LocationName = "Puducherry" };
        //Location location2 = new Location { LocationID = 2, LocationName = "Chennai" };

        //CourierCompany company1 = new CourierCompany
        //{
        //    CompanyID = 1,
        //    CompanyName = "FastTag",
        //    LocationDetails = new List<Location> { location1 }
        //};

        //CourierCompany company2 = new CourierCompany
        //{
        //    CompanyID = 2,
        //    CompanyName = "DTDC",
        //    LocationDetails = new List<Location> { location2 }
        //};

        //service.AddCourierCompany(company1);
        //service.AddCourierCompany(company2);

        //foreach (var company in service.GetAllCourierCompanies())
        //{
        //    Console.WriteLine($"CompanyID: {company.CompanyID}, Name: {company.CompanyName}");
        //    foreach (var loc in company.LocationDetails)
        //    {
        //        Console.WriteLine($"  Location: {loc.LocationName}");
        //    }
        //}

        //Console.ReadLine();

        //2.
        //CourierCompany company1 = new CourierCompany
        //{
        //    CompanyID = 1,
        //    CompanyName = "Delivery",
        //    LocationDetails = new List<Location> { new Location { LocationID = 1, LocationName = "Puducherry" } }
        //};

        //CourierCompany company2 = new CourierCompany
        //{
        //    CompanyID = 2,
        //    CompanyName = "Express",
        //    LocationDetails = new List<Location> { new Location { LocationID = 2, LocationName = "Chennai" } }
        //};

        //service.AddCourierCompany(company1);
        //service.AddCourierCompany(company2);

        //Console.WriteLine("List of Courier Companies:");
        //foreach (var company in service.GetAllCourierCompanies())
        //{
        //    Console.WriteLine($"ID: {company.CompanyID}, Name: {company.CompanyName}");
        //    foreach (var loc in company.LocationDetails)
        //    {
        //        Console.WriteLine($"  - Location ID: {loc.LocationID}, Name: {loc.LocationName}");
        //    }
        //}
        //Task 8
        //1.
        //Courier courier = new Courier
        //{
        //    CourierID = 1,
        //    TrackingNumber = "TN2025N001",
        //    SenderName = "James",
        //    SenderAddress = "Puducherry",
        //    ReceiverName = "Shyla",
        //    ReceiverAddress = "Chennai",
        //    Weight = 1.5,
        //    Status = "In Transit",
        //    CourierStaffID = 101,
        //    CustomerID = 11,
        //    DeliveryDate = DateTime.Now.AddDays(2)
        //};

        //userService.PlaceOrder(courier);
        //Console.WriteLine(userService.GetOrderStatus("TN2025N001"));
        //userService.DeliverOrder("TN2025N001");
        //Console.WriteLine(userService.GetOrderStatus("TN2025N001"));

        //2.
        //company.CourierDetails.Add(new Courier { TrackingNumber = "TN001", Status = "In Transit" });
        //company.CourierDetails.Add(new Courier { TrackingNumber = "TN002", Status = "Pending" });

        //CourierAdminServiceImpl adminService = new CourierAdminServiceImpl(company);

        //Console.WriteLine("Updating status for TN001");
        //adminService.UpdateCourierStatus("TN001", "Delivered");

        //Console.WriteLine("Removing TN002");
        //adminService.RemoveCourierByTrackingNumber("TN002");

        //Console.WriteLine("\nRemaining couriers:");
        //foreach (var courier in company.CourierDetails)
        //{
        //    Console.WriteLine($"Tracking: {courier.TrackingNumber}, Status: {courier.Status}");
        //}
        //3.
        //var company = new CourierCompanyCollection();
        //var adminService = new CourierAdminServiceCollectionImpl(company);

        //company.Couriers.Add(new Courier { TrackingNumber = "TC123", Status = "Pending", CustomerID = "1001" });

        //adminService.UpdateCourierStatus("TC123", "Delivered");
        //adminService.RemoveCourierByTrackingNumber("TC123");

        //Task 9
        //1.
        var connection = DbConnection.GetConnection();
        connection.Close();
        //2.
        CourierServiceDb db = new CourierServiceDb();
        //db.TestConnection();
        //Task 9(3)
        //db.InsertCourier(11, "Noah Collins", "12 Palm Street", "Emma Carter", "88 River View", 2.25, "In Transit", "TN12360", DateTime.Now);
        //db.UpdateCourierStatus(3, "Delivered");
        //db.GetAllCouriers();
        //Task 9(4)
        Console.WriteLine("--Delivery History by Tracking Number--");
        db.GetCourierByTrackingNumber();

        db.GenerateShipmentStatusReport();

        db.GenerateRevenueReport();
    }
}




