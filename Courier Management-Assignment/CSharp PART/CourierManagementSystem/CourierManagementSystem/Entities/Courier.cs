using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class Courier
    {
        private static int _trackingNumberCounter = 100;

        public long courierID;
        public string senderName;
        public string senderAddress;
        public string receiverName;
        public string receiverAddress;
        public double weight;
        public string status;
        public string trackingNumber;
        public DateTime deliveryDate;
        public int courierStaffID;
        public string customerID;
        public Customer Customer { get; set; } //Task8(3)



        public Courier()
        {
        }
        public Courier(long courierID, string senderName, string senderAddress, string receiverName,
                       string receiverAddress, double weight, string status, string trackingNumber,
                       DateTime deliveryDate, int courierStaffID, string customerID)
        {
            this.courierID = courierID;
            this.senderName = senderName;
            this.senderAddress = senderAddress;
            this.receiverName = receiverName;
            this.receiverAddress = receiverAddress;
            this.weight = weight;
            this.status = status;
            this.trackingNumber = trackingNumber;
            this.deliveryDate = deliveryDate;
            this.courierStaffID = courierStaffID;
            this.customerID = customerID;
        }
        public long CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }

        public string ReceiverName
        {
            get { return receiverName; }
            set { receiverName = value; }
        }

        public string ReceiverAddress
        {
            get { return receiverAddress; }
            set { receiverAddress = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }
        public int CourierStaffID
        {
            get { return courierStaffID; }
            set { courierStaffID = value; }
        }

        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public override string ToString()
        {
            return $"Courier Details:\n" +
           $"Courier ID     : {CourierID}\n" +
           $"Tracking #     : {TrackingNumber}\n" +
           $"Sender         : {SenderName} ({SenderAddress})\n" +
           $"Receiver       : {ReceiverName} ({ReceiverAddress})\n" +
           $"Weight         : {Weight} kg\n" +
           $"Status         : {Status}\n" +
           $"Delivery Date  : {DeliveryDate:dd-MM-yyyy}\n" +
           $"Assigned Staff : {CourierStaffID}\n" +
           $"Customer ID    : {CustomerID}\n";
        }
    }
}


