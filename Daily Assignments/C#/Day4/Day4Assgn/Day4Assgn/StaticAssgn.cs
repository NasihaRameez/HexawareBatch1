using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Assgn
{
    class StaticAssgn
    {
        private static int count = 0;
        public static void CountFunction()
        {
            count++;
            Console.WriteLine($"CountFunction has been called {count} time(s).");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StaticAssgn.CountFunction();
            StaticAssgn.CountFunction();
            StaticAssgn.CountFunction();
            StaticAssgn.CountFunction();
            StaticAssgn.CountFunction();

            Console.ReadLine();
        }
    }
}

