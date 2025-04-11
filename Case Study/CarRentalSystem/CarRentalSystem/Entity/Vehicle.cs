using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{
        public class Vehicle
        {
            public int VehicleID { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public decimal DailyRate { get; set; }
            public string Status { get; set; }
            public int PassengerCapacity { get; set; }
            public int EngineCapacity { get; set; }

            public Vehicle() { }

            public Vehicle(int vehicleID, string make, string model, int year, decimal dailyRate, string status, int passengerCapacity, int engineCapacity)
            {
                VehicleID = vehicleID;
                Make = make;
                Model = model;
                Year = year;
                DailyRate = dailyRate;
                Status = status;
                PassengerCapacity = passengerCapacity;
                EngineCapacity = engineCapacity;
            }

            public override string ToString()
            {
                return $"--- Vehicle Details ---\n" +
                       $"Vehicle ID        : {VehicleID}\n" +
                       $"Make              : {Make}\n" +
                       $"Model             : {Model}\n" +
                       $"Year              : {Year}\n" +
                       $"Daily Rate        : Rs.{DailyRate:F2}\n" +
                       $"Status            : {Status}\n" +
                       $"Passenger Capacity: {PassengerCapacity}\n" +
                       $"Engine Capacity   : {EngineCapacity} cc\n";
            }
        }
    }
