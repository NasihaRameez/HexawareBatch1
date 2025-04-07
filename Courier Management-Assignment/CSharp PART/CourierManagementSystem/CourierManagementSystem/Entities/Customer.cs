using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class Customer
    {
        public string customerID;
        private string customerName;
        private string email;
        private string password;
        private string contactNumber;
        private string address;
        public Customer()
        {
        }
        public Customer(string customerID, string customerName, string email, string password, string contactNumber, string address)
        {
            this.customerID = customerID;
            this.customerName = customerName;
            this.email = email;
            this.password = password;
            this.contactNumber = contactNumber;
            this.address = address;
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public override string ToString()
        {
            return $"CustomerID: {customerID}, Name: {customerName}, Email: {email}, Contact: {contactNumber}, Address: {address}";
        }
    }
}


