using OrderManagementSystem.Dao;
using OrderManagementSystem.Entity;
using OrderManagementSystem.Util;
using System.Data.SqlClient;

namespace OrderManagementSystem.Main
{
    internal class MainModule
    {
        //static void Main(string[] args)
        //{
        //    User user = new User(1, "Nasiha", "password123", "Admin");
        //    Console.WriteLine(user);

        //    // Create an Electronics product
        //    Electronics phone = new Electronics(1, "Smartphone", "5G phone", 24999.99, 20, "Electronics", "Samsung", 23);

        //    // Create a Clothing product
        //    Clothing dress = new Clothing(2, "BIBA Kurta", "Cotton ethnic wear", 1299.99, 10, "Clothing", "M", "Blue");

        //    // Simulate a list of products (for order)
        //    List<Product> orderItems = new List<Product> { phone, dress };

        //    // Display order items
        //    foreach (var item in orderItems)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Order order1 = new Order(1, new List<Product> { dress });

        //    // Use the OrderProcessor to manage orders
        //    OrderProcessor processor = new OrderProcessor();
        //    processor.AddOrder(order1);

        //    // Display all orders
        //    Console.WriteLine("=== Orders ===");
        //    foreach (var order in processor.GetAllOrders())
        //    {
        //        Console.WriteLine($"Order ID: {order.OrderId}, Total: Rs.{order.TotalAmount}");
        //    }

        //}

    }
}
 
