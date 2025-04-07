using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CourierManagementSystem.Util;

namespace CourierManagementSystem.Dao
{
    public class CourierServiceDb
    {
        public static SqlConnection connection;

        public CourierServiceDb()
        {
            connection = DbConnection.GetConnection();
        }

        public void TestConnection()
        {
            if (connection != null)
            {
                Console.WriteLine("CourierServiceDb connection established.");
            }
            else
            {
                Console.WriteLine("Connection failed.");
            }
        }
        //Task 9
        //3.
        //Insert Values
        public void InsertCourier(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, string trackingNumber, DateTime DeliveryDate)
        {
            string query = @"INSERT INTO Couriers 
                            (CourierID, SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate) 
                            VALUES 
                            (@CourierID, @SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status, @TrackingNumber, @DeliveryDate)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {

                cmd.Parameters.AddWithValue("@CourierID", courierID);
                cmd.Parameters.AddWithValue("@SenderName", senderName);
                cmd.Parameters.AddWithValue("@SenderAddress", senderAddress);
                cmd.Parameters.AddWithValue("@ReceiverName", receiverName);
                cmd.Parameters.AddWithValue("@ReceiverAddress", receiverAddress);
                cmd.Parameters.AddWithValue("@Weight", weight);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);
                cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Courier record inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting courier: " + ex.Message);
                }
            }
        }
        //Update Values
        public void UpdateCourierStatus(int courierId, string newStatus)
        {
            string query = "UPDATE Couriers SET Status = @Status WHERE CourierId = @CourierId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@CourierId", courierId);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Courier status updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating courier status: " + ex.Message);
                }
            }
        }
        //Retrieve data 
        public void GetAllCouriers()
        {
            string query = "SELECT * FROM Couriers";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"ID: {reader["CourierId"]}, Sender: {reader["SenderName"]}, Receiver: {reader["ReceiverName"]}, " +
                                $"Weight: {reader["Weight"]} kg, Status: {reader["Status"]}, Tracking #: {reader["TrackingNumber"]}, " +
                                $"Date: {Convert.ToDateTime(reader["DeliveryDate"]).ToShortDateString()}"
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving courier data: " + ex.Message);
                }
            }
        }
        //4.
        //Delivery history by tracking number
        public void GetCourierByTrackingNumber()
        {
            Console.Write("Enter Tracking Number: ");
            string trackingNumber = Console.ReadLine();

            string query = "SELECT * FROM Couriers WHERE TrackingNumber = @TrackingNumber";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["CourierID"]}, Sender: {reader["SenderName"]}, Receiver: {reader["ReceiverName"]}, " +
                                      $"Status: {reader["Status"]}, Tracking Number: {reader["TrackingNumber"]}, Date: {Convert.ToDateTime(reader["DeliveryDate"]).ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No parcel found with that tracking number.");
            }

            reader.Close();
        }
        //Shipment status report
        public void GenerateShipmentStatusReport()
        {
            string query = "SELECT Status, COUNT(*) AS Count FROM Couriers GROUP BY Status";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("--Shipment Status Report--");
            while (reader.Read())
            {
                Console.WriteLine($"Status: {reader["Status"]}, Count: {reader["Count"]}");
            }

            reader.Close();
        }
        //Revenue report
        public void GenerateRevenueReport()
        {
            string query = "SELECT SUM(Amount) AS TotalRevenue FROM Payment";

            SqlCommand cmd = new SqlCommand(query, connection);
            object result = cmd.ExecuteScalar();

            Console.WriteLine($"--Revenue Report-- \nTotal Revenue: Rs.{Convert.ToDecimal(result):F2}");
        }



    }
}
