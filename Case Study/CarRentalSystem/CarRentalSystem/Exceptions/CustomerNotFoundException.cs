using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        //public CustomerNotFoundException() : base("Customer not found in the database.") { }

        public CustomerNotFoundException(string message) : base(message) { }

        public CustomerNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
