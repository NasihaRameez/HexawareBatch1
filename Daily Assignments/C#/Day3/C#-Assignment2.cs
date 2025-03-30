using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Write a C# Sharp program to swap two numbers.
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before swapping: num1 = " + num1 + ", num2 = " + num2);

            int temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("After swapping: num1 = " + num1 + ", num2 = " + num2);

            //2.Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.

            Console.Write("Enter a digit: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);

            //3.Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.
            // Read a day number and display the corresponding day name
            Console.Write("Enter a day number (1-7): ");
            int dayNumber = Convert.ToInt32(Console.ReadLine());

            string dayName;
            switch (dayNumber)
            {
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                case 7:
                    dayName = "Sunday";
                    break;
                default:
                    dayName = "Invalid day number";
                    break;
            }

            Console.WriteLine("Day: " + dayName);
            //Arrays:
            //1.Write a  Program to assign integer values to an array  and then print the following
            //a.Average value of Array elements
            //b.Minimum and Maximum value in an array
            Console.Write("Enter the number of elements: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[size];

            // Get array elements from the user
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter element " + (i + 1) + ": ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Calculate the average value of array elements
            double sum = 0;
            foreach (int numElement in numbers)
            {
                sum += numElement;
            }
            double average = sum / numbers.Length;
            Console.WriteLine("Average value of array elements: " + average);

            // Find the minimum and maximum values in the array
            int min = numbers[0];
            int max = numbers[0];

            foreach (int numElement in numbers)
            {
                if (numElement < min)
                    min = numElement;
                if (numElement > max)
                    max = numElement;
            }

            Console.WriteLine("Minimum value in array: " + min);
            Console.WriteLine("Maximum value in array: " + max);

            //2.Write a program in C# to accept ten marks and display the following
            //a.Total
            //b.Average
            //c.Minimum marks
            //d.Maximum marks
            //e.Display marks in ascending order
            //f.Display marks in descending order
            Console.Write("Enter 10 marks separated by spaces: ");
            string[] inputMarks = Console.ReadLine().Split(' ');
            int[] marks = new int[10];

            for (int i = 0; i < 10; i++)
            {
                marks[i] = Convert.ToInt32(inputMarks[i]);
            }

            // Calculate total and average
            int total = 0;
            for (int i = 0; i < 10; i++)
            {
                total += marks[i];
            }
            double average1 = (double)total / 10;

            // Find the minimum and maximum marks
            int minMark = marks[0], maxMark = marks[0];
            for (int i = 1; i < 10; i++)
            {
                if (marks[i] < minMark) minMark = marks[i];
                if (marks[i] > maxMark) maxMark = marks[i];
            }

            // Sort marks for ascending and descending order
            Array.Sort(marks);

            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average Marks: " + average1);
            Console.WriteLine("Minimum Marks: " + minMark);
            Console.WriteLine("Maximum Marks: " + maxMark);

            Console.Write("Marks in Ascending Order: ");
            Console.WriteLine(string.Join(" ", marks));

            Console.Write("Marks in Descending Order: ");
            Array.Reverse(marks);
            Console.WriteLine(string.Join(" ", marks));

            //3.Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)
            // Copy elements of one array into another array manually
            Console.Write("Enter the number of elements for copying: ");
            int copySize = Convert.ToInt32(Console.ReadLine());
            int[] sourceArray = new int[copySize];
            int[] destinationArray = new int[copySize];

            Console.Write("Enter " + copySize + " numbers separated by spaces: ");
            string[] copyInputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < copySize; i++)
            {
                sourceArray[i] = Convert.ToInt32(copyInputs[i]);
                destinationArray[i] = sourceArray[i];
            }

            Console.Write("Copied Array: ");
            Console.WriteLine(string.Join(" ", destinationArray));


        }
    }
}

       




