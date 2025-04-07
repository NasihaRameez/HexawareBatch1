using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Courier Management System - Task 1 -----\n");

            // 1.Write a program that checks whether a given order is delivered or not based on its status 
            Console.WriteLine("1. Order Delivery Status Check");

            string orderStatus = "Delivered";
            Console.WriteLine("Order Status: " + orderStatus);

            if (orderStatus == "Delivered")
            {
                Console.WriteLine("The order has been delivered.\n");
            }
            else if (orderStatus == "Processing" || orderStatus == "In Transit")
            {
                Console.WriteLine("The order is still being processed.\n");
            }
            else if (orderStatus == "Cancelled")
            {
                Console.WriteLine("The order has been cancelled.\n");
            }
            else
            {
                Console.WriteLine("Unknown order status.\n");
            }
            //2.Implement a switch-case statement to categorize parcels based on their weight into "Light,", "Medium," or "Heavy."
            Console.WriteLine("2. Parcel Weight Categorization");

            double parcelWeight = 3.0;
            Console.WriteLine("Parcel Weight: " + parcelWeight + " kg");

            string weightCategory = "";

            if (parcelWeight < 2)
                weightCategory = "Light";
            else if (parcelWeight < 5)
                weightCategory = "Medium";
            else
                weightCategory = "Heavy";

            switch (weightCategory)
            {
                case "Light":
                    Console.WriteLine("Parcel is Light.\n");
                    break;
                case "Medium":
                    Console.WriteLine("Parcel is Medium weight.\n");
                    break;
                case "Heavy":
                    Console.WriteLine("Parcel is Heavy.\n");
                    break;
                default:
                    Console.WriteLine("Invalid weight category.\n");
                    break;
            }

            // 3.Implement User Authentication 1. Create a login system for employees and customers using C# control flow statements.
            Console.WriteLine("3. User Login");

            string[] employeeEmails = { "employee1@courier.com", "employee2@courier.com" };
            string[] employeePasswords = { "emp123", "emp456" };

            string[] customerEmails = { "johndoe@example.com", "janesmith@example.com" };
            string[] customerPasswords = { "password123", "password456" };

            Console.WriteLine("\nAvailable Employee Accounts:");
            for (int i = 0; i < employeeEmails.Length; i++)
            {
                Console.WriteLine($"Email: {employeeEmails[i]}, Password: {employeePasswords[i]}");
            }

            Console.WriteLine("\nAvailable Customer Accounts:");
            for (int i = 0; i < customerEmails.Length; i++)
            {
                Console.WriteLine($"Email: {customerEmails[i]}, Password: {customerPasswords[i]}");
            }

            string inputEmail = "johndoe@example.com";
            string inputPassword = "password123";

            bool isAuthenticated = false;

            for (int i = 0; i < employeeEmails.Length; i++)
            {
                if (inputEmail == employeeEmails[i] && inputPassword == employeePasswords[i])
                {
                    Console.WriteLine("\nEmployee login successful.\n");
                    isAuthenticated = true;
                    break;
                }
            }

            if (!isAuthenticated)
            {
                for (int i = 0; i < customerEmails.Length; i++)
                {
                    if (inputEmail == customerEmails[i] && inputPassword == customerPasswords[i])
                    {
                        Console.WriteLine("\nCustomer login successful.\n");
                        isAuthenticated = true;
                        break;
                    }
                }
            }

            if (!isAuthenticated)
            {
                Console.WriteLine("\nLogin failed. Invalid credentials.\n");
            }

            // 4.Implement Courier Assignment Logic 1. Develop a mechanism to assign couriers to shipments based on predefined criteria(e.g., proximity, load capacity) using loops.
            Console.WriteLine("4. Courier Assignment");

            string[] availableCouriers = { "Courier A", "Courier B", "Courier C" };
            string assignedCourier = null;

            Console.WriteLine("\nAvailable Couriers:");
            for (int i = 0; i < availableCouriers.Length; i++)
            {
                Console.WriteLine(availableCouriers[i]);
            }

            for (int i = 0; i < availableCouriers.Length; i++)
            {
                bool isAvailable = true;
                if (isAvailable)
                {
                    assignedCourier = availableCouriers[i];
                    break;
                }
            }

            if (assignedCourier != null)
            {
                Console.WriteLine("Assigned Courier: " + assignedCourier + "\n");
            }
            else
            {
                Console.WriteLine("No courier available for assignment.\n");
            }
        }
    }
}
