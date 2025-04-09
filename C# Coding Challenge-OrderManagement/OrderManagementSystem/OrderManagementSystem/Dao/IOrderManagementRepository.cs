using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace OrderManagementSystem.Dao
{
    //6.
    public interface IOrderManagementRepository
    {
        ////1. Create an order
        //void CreateOrder(User user, List<Product> products);

        //// 2. Cancel an order
        //void CancelOrder(int userId, int orderId);

        //// 3. Create a new product
        //void CreateProduct(User user, Product product);

        //// 4. Create a new user
        //void CreateUser(User user);

        //// 5. Get all products
        //List<Product> GetAllProducts();

        //// 6. Get all orders by a specific user
        //List<Product> GetOrderByUser(User user);

        //7.
        //void AddOrder(Order order);
        //void RemoveOrder(int orderId);
        //Order GetOrder(int orderId);
        //List<Order> GetAllOrders();

        //Task 9
        void CreateUser(User user);
        void CreateProduct(User adminUser, Product product);
        List<Product> GetAllProducts();
        void CreateOrder(User user, List<Product> products);
        void CancelOrder(int userId, int orderId);
        List<Product> GetOrderByUser(User user);
    }
}
