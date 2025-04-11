using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Exceptions
{
    public class LeaseNotFoundException : Exception
    {
        public LeaseNotFoundException() : base("Lease not found in the database.") { }

        public LeaseNotFoundException(string message) : base(message) { }

        public LeaseNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
