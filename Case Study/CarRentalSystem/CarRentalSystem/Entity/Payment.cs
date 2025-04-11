using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{
        public class Payment
        {
            public int PaymentID { get; set; }
            public int LeaseID { get; set; }
            public DateTime PaymentDate { get; set; }
            public double Amount { get; set; }

            public Payment() { }

            public Payment(int paymentID, int leaseID, DateTime paymentDate, double amount)
            {
                PaymentID = paymentID;
                LeaseID = leaseID;
                PaymentDate = paymentDate;
                Amount = amount;
            }

            public override string ToString()
            {
                return $"--- Payment Details ---\n" +
                       $"Payment ID    : {PaymentID}\n" +
                       $"Lease ID      : {LeaseID}\n" +
                       $"Payment Date  : {PaymentDate:dd-MM-yyyy}\n" +
                       $"Amount Paid   : ₹{Amount:F2}\n";
            }
        }
}

