using System;

namespace Day4Assgn
{
    //Inheritance
    class Employee
    {
        public int Id;
        public string Name;
        public string Dob;
        public double Salary;

        public Employee(int id, string name, string dob, double salary)
        {
            Id = id;
            Name = name;
            Dob = dob;
            Salary = salary;
        }
        public virtual double ComputeSalary()
        {
            return Salary;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("DOB: " + Dob);
            Console.WriteLine("Base Salary: " + Salary);
            Console.WriteLine("Total Salary: " + ComputeSalary());
        }
    }
    class Manager : Employee
    {
        public double OnsiteAllowance;
        public double Bonus;

        public Manager(int id, string name, string dob, double salary, double onsiteAllowance, double bonus)
            : base(id, name, dob, salary)
        {
            OnsiteAllowance = onsiteAllowance;
            Bonus = bonus;
        }

        public override double ComputeSalary()
        {
            return Salary + OnsiteAllowance + Bonus;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("DOB: " + Dob);
            Console.WriteLine("Base Salary: " + Salary);
            Console.WriteLine("Onsite Allowance: " + OnsiteAllowance);
            Console.WriteLine("Bonus: " + Bonus);
            Console.WriteLine("Total Salary (with allowance & bonus): " + ComputeSalary());
        }
    }

    //internal class Program
    //{
        //static void Main(string[] args)
        //{
        //    Employee emp = new Employee(1, "Naveen Kumar", "2002-12-25", 25000);
        //    Console.WriteLine("=== Employee Details ===");
        //    emp.DisplayDetails();

        //    Console.WriteLine();

        //    Manager mgr = new Manager(2, "Riya Sharma", "1998-07-10", 40000, 8000, 8000);
        //    Console.WriteLine("=== Manager Details ===");
        //    mgr.DisplayDetails();

        //    Console.ReadLine();
        //}
    //}
}

