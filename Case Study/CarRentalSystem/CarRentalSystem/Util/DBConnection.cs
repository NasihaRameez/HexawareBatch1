using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace CarRentalSystem.Util
{
    public class DBConnection
    {
        public static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                try
                {
                    var props = PropertyUtil.LoadProperties("db.properties");

                    string hostname = props.ContainsKey("hostname") ? props["hostname"] : "localhost";
                    string dbname = props.ContainsKey("dbname") ? props["dbname"] : "CarRentaldb";

                    string connectionString = $"Server={hostname};Initial Catalog={dbname};Integrated Security=True;";

                   
                    connection = new SqlConnection(connectionString);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to create or open the database connection.", ex);
                }
            }
            return connection;
        }
    }
}