using System;

class Program
{
    static void Main()
    {
        //1.Write a C# Sharp program to accept two integers and check whether they are equal or not.
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 == num2)
            Console.WriteLine("Both numbers are equal.");
        else
            Console.WriteLine("Numbers are not equal.");
        {
            //2.Write a C# Sharp program to check whether a given number is positive or negative.
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num > 0)
                Console.WriteLine($"{num} is a positive number.");
            else if (num < 0)
                Console.WriteLine($"{num} is a negative number.");
            else
                Console.WriteLine("The number is zero.");
        }

        {
            //3.Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 
            double number1 = Convert.ToDouble(Console.ReadLine());
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();
            double number2 = Convert.ToDouble(Console.ReadLine());
            double result;
            if (operation == '+')
                result = number1 + number2;
            else if (operation == '-')
                result = number1 - number2;
            else if (operation == '*')
                result = number1 * number2;
            else if (operation == '/')
            {
                if (number2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return;
                }
                result = number1 / number2;
            }
            else
            {
                Console.WriteLine("Invalid operation.");
                return;
            }

            Console.WriteLine(number1 + " " + operation + " " + number2 + " = " + result);
        }
        {
            //4.Write a C# Sharp program that prints the multiplication table of a number as input.
            Console.Write("Enter the number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(number + " * " + i + " = " + (number * i));
            }
        }
        {
            //5.Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.
            Console.Write("Enter first number: ");
            int number3 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int number4 = Convert.ToInt32(Console.ReadLine());

            int sum = number3 + number4;

            if (number3 == number4)
            {
                Console.WriteLine("The result is: " + (sum * 3));
            }
            else
            {
                Console.WriteLine("The result is: " + sum);
            }
        }
    }
}








