using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourierManagementSystem.Util
{
    public class DbConnection
    {
        private static string connectionString = "Data Source=DESKTOP-AUT68C9\\SQLEXPRESS;Initial Catalog=CourierManagementdb;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Database connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }
            return connection;
        }
    }
}

