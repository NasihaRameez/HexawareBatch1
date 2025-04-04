using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment3
{
    class Interface_Assgn3
    {
        interface IStudent
        {
            int StudentId { get; set; }
            string Name { get; set; }
            double Fees { get; set; }
            void ShowDetails();
        }
        class Dayscholar : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public double Fees { get; set; }

            public Dayscholar(int id, string name, double fees)
            {
                StudentId = id;
                Name = name;
                Fees = fees;
            }

            public void ShowDetails()
            {
                Console.WriteLine("Dayscholar Student ID: " + StudentId + "\nName: " + Name + "\nTotal Fees: " + Fees + "\n");
            }
        }
        class Resident : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public double Fees { get; set; }
            public double AccommodationFees { get; set; }

            public Resident(int id, string name, double fees, double accommodationFees)
            {
                StudentId = id;
                Name = name;
                Fees = fees;
                AccommodationFees = accommodationFees;
            }

            public void ShowDetails()
            {
                double totalFees = Fees + AccommodationFees;
                Console.WriteLine("Resident Student ID: " + StudentId + "\nName: " + Name + "\nTuition Fees: " + Fees + "\nAccommodation Fees: " + AccommodationFees + "\nTotal Fees: " + totalFees + "\n");
            }
        }
        //class Program
        //{
        //    static void Main()
        //    {
        //        IStudent dayScholar = new Dayscholar(101, "Alice", 50000);
        //       IStudent resident = new Resident(102, "Bob", 50000, 20000);

        //        dayScholar.ShowDetails();
        //        resident.ShowDetails();
        //    }
        //}
    }
}

