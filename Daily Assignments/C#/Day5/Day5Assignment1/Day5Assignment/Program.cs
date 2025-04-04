using System;

namespace Day5Assignment
{
    internal class TimePeriod
    {
        private double seconds;

        
        public double Hours
        {
            get { return seconds / 3600; } 
            set { seconds = value * 3600; } 
        }

        
        public TimePeriod(double hours)
        {
            Hours = hours; 
        }

        public override string ToString()
        {
            return "TimePeriod: " + Hours + " hours (" + seconds + " seconds)";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter time in hours: ");
            double inputHours = Convert.ToDouble(Console.ReadLine());

            TimePeriod time = new TimePeriod(inputHours);
            Console.WriteLine(time);
        }
    }
}
