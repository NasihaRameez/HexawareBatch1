using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class CourierCompany
    {
        private int companyID;
        private string companyName;
        private List<Courier> courierDetails;
        private List<Employee> employeeDetails;
        private List<Location> locationDetails;

        public CourierCompany()
        {
            courierDetails = new List<Courier>();
            employeeDetails = new List<Employee>();
            locationDetails = new List<Location>();
        }
        public CourierCompany(int companyID, string companyName, List<Courier> courierDetails, List<Employee> employeeDetails, List<Location> locationDetails)
        {
            this.companyID = companyID;
            this.companyName = companyName;
            this.courierDetails = courierDetails;
            this.employeeDetails = employeeDetails;
            this.locationDetails = locationDetails;
        }
        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public List<Courier> CourierDetails
        {
            get { return courierDetails; }
            set { courierDetails = value; }
        }

        public List<Employee> EmployeeDetails
        {
            get { return employeeDetails; }
            set { employeeDetails = value; }
        }

        public List<Location> LocationDetails
        {
            get { return locationDetails; }
            set { locationDetails = value; }
        }
        public override string ToString()
        {
            return $"Company ID: {companyID}, Company Name: {companyName}, Couriers: {courierDetails.Count}, Employees: {employeeDetails.Count}, Location: {locationDetails.Count}";
        }
    }
}


