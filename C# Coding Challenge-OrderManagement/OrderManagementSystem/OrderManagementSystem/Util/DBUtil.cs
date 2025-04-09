using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrderManagementSystem.Util
{
    public class DBUtil
    {
        public static SqlConnection GetDBConn()
        {
            string connectionString = "Data Source=DESKTOP-AUT68C9\\SQLEXPRESS;Initial Catalog=OrderManagementDB;Integrated Security=True";

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connected to database successfully.");
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
                return null;
            }
        }
    }
}
