using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    class Task3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Task 3: Arrays and Data Structures -----\n");

            //7.Create an array to store the tracking history of a parcel, where each entry represents a location update.

            Console.WriteLine("7. Parcel Tracking History:");

            string[] trackingHistory = {
                "Dispatched from Warehouse",
                "Reached Hub - City A",
                "In Transit",
                "Reached Hub - City B",
                "Out for Delivery",
                "Delivered"
            };

            Console.WriteLine("Tracking Data:");
            for (int i = 0; i < trackingHistory.Length; i++)
            {
                Console.WriteLine($"Update {i + 1}: {trackingHistory[i]}");
            }

            Console.WriteLine();

            //8.Implement a method to find the nearest available courier for a new order using an array of couriers. 
            Console.WriteLine("8. Finding Nearest Available Courier:");

            string[] couriers = { "Courier A", "Courier B", "Courier C", "Courier D" };
            bool[] isAvailable = { false, true, true, false };
            double[] distances = { 10.5, 4.2, 6.8, 12.3 };

            Console.WriteLine("Inserted Courier Data:");
            for (int i = 0; i < couriers.Length; i++)
            {
                Console.WriteLine($"{couriers[i]} - Available: {isAvailable[i]}, Distance: {distances[i]} km");
            }

            string nearestCourier = null;
            double minDistance = double.MaxValue;

            for (int i = 0; i < couriers.Length; i++)
            {
                if (isAvailable[i] && distances[i] < minDistance)
                {
                    minDistance = distances[i];
                    nearestCourier = couriers[i];
                }
            }

            Console.WriteLine();

            if (nearestCourier != null)
            {
                Console.WriteLine($"Nearest Available Courier: {nearestCourier} (Distance: {minDistance} km)");
            }
            else
            {
                Console.WriteLine("No courier available at the moment.");
            }
        }
    }
}
