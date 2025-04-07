using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    class Task2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Courier Management System - Task 2 -----\n");

            //5.Write a C# program that uses a for loop to display all the orders for a specific customer.  
            string customerName = "John Doe";
            string[] johnOrders = { "Order1: Laptop", "Order2: Headphones" };

            Console.WriteLine($"5. Orders for customer: {customerName}");
            for (int i = 0; i < johnOrders.Length; i++)
            {
                Console.WriteLine(johnOrders[i]);
            }

            Console.WriteLine();

            //6.Implement a while loop to track the real-time location of a courier until it reaches its destination.  
            int customerId = 10;
            int courierLocation = 0;
            int destination = 5;

            Console.WriteLine($"6. Real-time Courier Tracking for Customer ID: {customerId}");
            while (courierLocation < destination)
            {
                Console.WriteLine($"Customer ID {customerId}: Courier is at location {courierLocation}");
                courierLocation++;
                Thread.Sleep(500);
            }

            Console.WriteLine($"Customer ID {customerId}: Courier has reached the destination!");

        }
    }
}
 