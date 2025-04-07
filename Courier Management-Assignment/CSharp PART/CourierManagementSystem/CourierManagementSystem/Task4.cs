using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CourierManagementSystem
{
    class Task4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Courier Management System : Task 4 ===\n");

            // Q9: Parcel Tracking using 2D String Array
            string[,] parcels = {
                { "TN001", "In Transit" },
                { "TN002", "Out for Delivery" },
                { "TN003", "Delivered" }
            };

            Console.Write("Enter Tracking Number (NY001-NY003): ");
            string trackNum = Console.ReadLine();
            TrackParcel(parcels, trackNum);

            // Q10: Customer Data Validation
            Console.WriteLine("\nValidating Customer Data:");
            Console.WriteLine(ValidateCustomerData("John Doe", "Name"));
            Console.WriteLine(ValidateCustomerData("123 John St.", "Address"));
            Console.WriteLine(ValidateCustomerData("987-654-3210", "Phone"));

            // Q11: Address Formatting
            Console.WriteLine("\nFormatted Address:");
            Console.WriteLine(FormatAddress("123 main st", "new york", "ny", "10001"));

            // Q12: Order Confirmation Email
            Console.WriteLine("\nOrder Confirmation Email:");
            GenerateOrderConfirmation("John Doe", "ORD12345", "123 Main St, New York, NY, 10001", "April 10, 2025");

            // Q13: Calculate Shipping Costs
            Console.WriteLine("\nShipping Cost: Rs." + CalculateShippingCost("Chennai", "Mumbai", 5));

            // Q14: Password Generator
            Console.WriteLine("\nGenerated Secure Password: " + GeneratePassword(12));

            // Q15: Find Similar Addresses
            Console.WriteLine("\nFinding Similar Addresses:");
            List<string> addresses = new List<string> {
                "123 Main St, New York, NY",
                "124 Main St, New York, NY",
                "123 Main Street, NY",
                "456 Elm St, Boston, MA"
            };
            FindSimilarAddresses(addresses, "123 Main St, New York, NY");

            Console.WriteLine("\nAll tasks completed. Press any key to exit.");
            Console.ReadKey();
        }

        // Q9: Parcel Tracking
        static void TrackParcel(string[,] parcels, string trackingNumber)
        {
            bool found = false;
            for (int i = 0; i < parcels.GetLength(0); i++)
            {
                if (parcels[i, 0] == trackingNumber)
                {
                    Console.WriteLine($"Parcel Status: {parcels[i, 1]}");
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine("Invalid tracking number.");
        }

        // Q10: Customer Data Validation
        static string ValidateCustomerData(string data, string detail)
        {
            if (detail.ToLower() == "name")
            {
                return Regex.IsMatch(data, @"^[A-Z][a-zA-Z\s]*$")
                    ? "Valid Name"
                    : "Invalid Name: Only letters allowed and should start with a capital letter.";
            }
            else if (detail.ToLower() == "address")
            {
                return !Regex.IsMatch(data, @"[!@#$%^&*(),?\\"":{}\|<>]")
                    ? "Valid Address"
                    : "Invalid Address: No special characters allowed.";
            }
            else if (detail.ToLower() == "phone")
            {
                return Regex.IsMatch(data, @"^\d{3}-\d{3}-\d{4}$")
                    ? "Valid Phone Number"
                    : "Invalid Phone Number: Format should be ###-###-####.";
            }
            return "Invalid Detail Type";
        }

        // Q11: Address Formatting
        static string FormatAddress(string street, string city, string state, string zip)
        {
            return $"{CapitalizeWords(street)}, {CapitalizeWords(city)}, {state.ToUpper()} {zip}";
        }

        static string CapitalizeWords(string input)
        {
            return string.Join(" ", input.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1)));
        }

        // Q12: Order Confirmation Email
        static void GenerateOrderConfirmation(string customerName, string orderNumber, string address, string deliveryDate)
        {
            string email = $"Dear {customerName},\n\nThank you for your order #{orderNumber}.\n" +
                           $"Your order will be delivered to:\n{address}\n\n" +
                           $"Expected delivery date: {deliveryDate}\n\nBest Regards,\nCourier Team";
            Console.WriteLine(email);
        }

        // Q13: Calculate Shipping Costs
        static double CalculateShippingCost(string source, string destination, double weight)
        {
            Dictionary<string, double> distances = new Dictionary<string, double>
            {
                { "Chennai-Mumbai", 1300 },
                { "Chennai-Delhi", 2200 },
                { "Mumbai-Delhi", 1400 }
            };

            string route = $"{source}-{destination}";
            return distances.ContainsKey(route) ? distances[route] * 0.05 + weight * 2.5 : 50 + weight * 2.5;
        }

        // Q14: Password Generator
        static string GeneratePassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Q15: Find Similar Addresses
        static void FindSimilarAddresses(List<string> addresses, string targetAddress)
        {
            Console.WriteLine($"Finding similar addresses to: {targetAddress}");
            foreach (var address in addresses)
            {
                int similarity = GetSimilarityScore(targetAddress, address);
                if (similarity >= 75)
                    Console.WriteLine($"Similar: {address} (Match: {similarity}%)");
            }
        }

        static int GetSimilarityScore(string str1, string str2)
        {
            int commonWords = str1.Split(' ').Intersect(str2.Split(' ')).Count();
            int totalWords = Math.Max(str1.Split(' ').Length, str2.Split(' ').Length);
            return (int)((double)commonWords / totalWords * 100);
        }
    }
}





