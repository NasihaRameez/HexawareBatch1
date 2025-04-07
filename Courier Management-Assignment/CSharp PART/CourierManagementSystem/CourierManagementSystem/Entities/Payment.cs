using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class Payment
    {
        private long paymentID;
        private long courierID;
        private double amount;
        private DateTime paymentDate;

        public Payment()
        {
        }

        public Payment(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.courierID = courierID;
            this.amount = amount;
            this.paymentDate = paymentDate;
        }
        public long PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public long CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
        public override string ToString()
        {
            return $"Payment ID: {paymentID}, Courier ID: {courierID}, Amount: {amount}, Date: {paymentDate.ToShortDateString()}";
        }
    }
}


