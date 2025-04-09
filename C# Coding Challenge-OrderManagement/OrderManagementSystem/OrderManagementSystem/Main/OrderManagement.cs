using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;
using OrderManagementSystem.Dao;

namespace OrderManagementSystem.Main
{
    class OrderManagement
    {
        static void Main(string[] args)
        {
            IOrderManagementRepository repo = new OrderProcessor();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. View All Products");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5. Cancel Order");
                Console.WriteLine("6. Get Order By User");
                Console.Write("Enter choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("User ID: ");
                        int userId = int.Parse(Console.ReadLine());
                        Console.Write("Username: ");
                        string uname = Console.ReadLine();
                        Console.Write("Password: ");
                        string pass = Console.ReadLine();
                        Console.Write("Role (Admin/User): ");
                        string role = Console.ReadLine();
                        repo.CreateUser(new User(userId, uname, pass, role));
                        break;

                    case "2":
                        Console.Write("Admin ID: ");
                        int adminId = int.Parse(Console.ReadLine());
                        Console.Write("Product ID: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Desc: ");
                        string desc = Console.ReadLine();
                        Console.Write("Price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("Quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        Console.Write("Type (Electronics/Clothing): ");
                        string type = Console.ReadLine();

                        Product prod = new Product(pid, name, desc, price, qty, type);
                        repo.CreateProduct(new User(adminId, "dummy", "pass", "Admin"), prod);
                        break;

                    case "3":
                        var list = repo.GetAllProducts();
                        foreach (var p in list)
                        {
                            Console.WriteLine(p);
                        }
                        break;


                    case "5":
                        Console.Write("Enter User ID: ");
                        int uid = int.Parse(Console.ReadLine());
                        Console.Write("Enter Order ID to cancel: ");
                        int oid = int.Parse(Console.ReadLine());
                        repo.CancelOrder(uid, oid);
                        break;

                    case "6":
                        Console.Write("Enter User ID to view orders: ");
                        int UserId = int.Parse(Console.ReadLine());
                        List<Product> orders = repo.GetOrderByUser(new User(UserId, "", "", "User"));
                        foreach (var p in orders)
                        {
                            Console.WriteLine(p);
                        }
                        break;
                    
                    case "4":
                        exit = true;
                        break;


                }
            }
        }
    }
}

