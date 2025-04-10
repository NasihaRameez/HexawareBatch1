﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{ 
        public class Lease
        {
            public int LeaseID { get; set; }
            public int VehicleID { get; set; }
            public int CustomerID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Type { get; set; }

            public Lease() { }

            public Lease(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime endDate, string type)
            {
                LeaseID = leaseID;
                VehicleID = vehicleID;
                CustomerID = customerID;
                StartDate = startDate;
                EndDate = endDate;
                Type = type;
            }

            public override string ToString()
            {
                return $"--- Lease Details ---\n" +
                       $"Lease ID      : {LeaseID}\n" +
                       $"Vehicle ID    : {VehicleID}\n" +
                       $"Customer ID   : {CustomerID}\n" +
                       $"Lease Type    : {Type}\n" +
                       $"Start Date    : {StartDate:dd-MM-yyyy}\n" +
                       $"End Date      : {EndDate:dd-MM-yyyy}\n";
            }
        }
}
