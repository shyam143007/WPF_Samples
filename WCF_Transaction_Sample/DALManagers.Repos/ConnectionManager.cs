using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALManagers.Repos
{
    public class ConnectionManager
    {
        public static SqlConnection GetSqlConnection()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TransDB"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
