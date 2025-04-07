using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Interfaces;

namespace CourierManagementSystem.Services
{
    public class CourierAdminService : ICourierAdminInterface
    {
        private static List<Employee> employees = new List<Employee>();
        private static int nextStaffId = 101;
        private static List<Employee> employeeList = new List<Employee>();
        private static int nextEmployeeId = 100;

        //public int AddCourierStaff(Employee obj)
        //{
        //    obj.EmployeeID = nextStaffId++;
        //    employees.Add(obj);
        //    Console.WriteLine("Courier staff added successfully!");
        //    Console.WriteLine($"Staff ID: {obj.EmployeeID}");
        //    return obj.EmployeeID;
        //}
        //public void ViewAllStaff()
        //{
        //    Console.WriteLine("Courier Staff List:");
        //    foreach (var emp in employees)
        //    {
        //        Console.WriteLine($"{emp.EmployeeID} - {emp.EmployeeName} ({emp.ContactNumber})");
        //    }
        //}
        public int AddCourierStaff(Employee obj)
        {
            obj.EmployeeID = nextEmployeeId++;
            employeeList.Add(obj);
            return obj.EmployeeID;
        }
        public bool IsValidEmployee(int empId)
        {
            return employeeList.Exists(e => e.EmployeeID == empId);
        }
    }
}
