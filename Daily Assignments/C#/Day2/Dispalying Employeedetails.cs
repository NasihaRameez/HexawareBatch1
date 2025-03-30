namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Designation: ");
            emp.Designation = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n====================\n");
            emp.DisplayDetails();
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Designation: " + Designation);
            Console.WriteLine("Salary: " + Salary);
        }
    }
}
