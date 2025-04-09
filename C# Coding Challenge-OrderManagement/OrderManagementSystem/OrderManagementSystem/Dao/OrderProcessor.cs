using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;
using OrderManagementSystem.Util;

namespace OrderManagementSystem.Dao
{
    public class OrderProcessor : IOrderManagementRepository
    {
        //private List<Order> orders = new List<Order>();

        //public void AddOrder(Order order)
        //{
        //    orders.Add(order);
        //    Console.WriteLine($"Order {order.OrderId} added successfully.");
        //}

        //public void RemoveOrder(int orderId)
        //{
        //    var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        //    if (order != null)
        //    {
        //        orders.Remove(order);
        //        Console.WriteLine($"Order {orderId} removed successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Order {orderId} not found.");
        //    }
        //}

        //public Order GetOrder(int orderId)
        //{
        //    return orders.FirstOrDefault(o => o.OrderId == orderId);
        //}

        //public List<Order> GetAllOrders()
        //{
        //    return orders;
        //}

        //Task 9
        public void CreateUser(User user)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string query = "INSERT INTO Users VALUES (@id, @username, @pass, @role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", user.UserId);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);

                cmd.ExecuteNonQuery();
                Console.WriteLine("User created successfully.");
            }
        }

        public void CreateProduct(User adminUser, Product product)
        {
            if (adminUser.Role != "Admin")
            {
                Console.WriteLine("Only Admin can create products.");
                return;
            }

            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string query = "INSERT INTO Product VALUES (@id, @name, @desc, @price, @qty, @type)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", product.ProductId);
                cmd.Parameters.AddWithValue("@name", product.ProductName);
                cmd.Parameters.AddWithValue("@desc", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@qty", product.QuantityInStock);
                cmd.Parameters.AddWithValue("@type", product.Type);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Product created successfully.");
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                string query = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product(
                        (int)reader["productId"],
                        (string)reader["productName"],
                        (string)reader["description"],
                        Convert.ToDouble(reader["price"]),
                        (int)reader["quantityInStock"],
                        (string)reader["type"]
                    );
                    products.Add(p);
                }
            }

            return products;
        }
        public void CreateOrder(User user, List<Product> products)
        {
            using (SqlConnection conn = DBUtil.GetDBConn())
            {
                SqlTransaction txn = conn.BeginTransaction();
                try
                {
                    string insertOrderQuery = "INSERT INTO Orders (orderId, userId) VALUES (@orderId, @userId)";
                    int newOrderId = new Random().Next(1000, 9999);

                    SqlCommand cmd = new SqlCommand(insertOrderQuery, conn, txn);
                    cmd.Parameters.AddWithValue("@orderId", newOrderId);
                    cmd.Parameters.AddWithValue("@userId", user.UserId);
                    cmd.ExecuteNonQuery();

                    foreach (var product in products)
                    {
                        string insertOrderProduct = "INSERT INTO OrderProducts (orderId, productId) VALUES (@oid, @pid)";
                        SqlCommand prodCmd = new SqlCommand(insertOrderProduct, conn, txn);
                        prodCmd.Parameters.AddWithValue("@oid", newOrderId);
                        prodCmd.Parameters.AddWithValue("@pid", product.ProductId);
                        prodCmd.ExecuteNonQuery();
                    }

                    txn.Commit();
                    Console.WriteLine($"Order {newOrderId} created successfully.");
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    Console.WriteLine("Order creation failed: " + ex.Message);
                }
            }
        }
        public void CancelOrder(int userId, int orderId)
        {
            try
            {
                using (SqlConnection conn = DBUtil.GetDBConn())
                {
                    string checkQuery = "SELECT COUNT(*) FROM Orders WHERE orderId = @oid AND userId = @uid";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@oid", orderId);
                    checkCmd.Parameters.AddWithValue("@uid", userId);

                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        Console.WriteLine("Order not found for the given user.");
                        return;
                    }

                    SqlCommand delOP = new SqlCommand("DELETE FROM OrderProducts WHERE orderId = @oid", conn);
                    delOP.Parameters.AddWithValue("@oid", orderId);
                    delOP.ExecuteNonQuery();

                    SqlCommand delO = new SqlCommand("DELETE FROM Orders WHERE orderId = @oid", conn);
                    delO.Parameters.AddWithValue("@oid", orderId);
                    delO.ExecuteNonQuery();

                    Console.WriteLine("Order cancelled successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public List<Product> GetOrderByUser(User user)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = DBUtil.GetDBConn())
                {
                    string query = @"
                SELECT p.productId, p.productName, p.description, p.price, p.quantityInStock, p.[type]
                FROM Orders o
                INNER JOIN OrderProducts op ON o.orderId = op.orderId
                INNER JOIN Product p ON p.productId = op.productId
                WHERE o.userId = @uid";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", user.UserId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product(
                            (int)reader["productId"],
                            (string)reader["productName"],
                            (string)reader["description"],
                            Convert.ToDouble(reader["price"]),
                            (int)reader["quantityInStock"],
                            (string)reader["type"]
                        );
                        products.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return products;
        }








    }
}

