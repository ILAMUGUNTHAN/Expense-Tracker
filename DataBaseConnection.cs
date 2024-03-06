using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker_Application
{
    public static class DataBaseConnection
    {

        private static string connectionString = "server=localhost;port=3306;uid=root;password=root;" + "database=expense_tracker";


        private static MySqlConnection connection ;

        static DataBaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static MySqlConnection GetConnection()
        {
            if (connection.State!=System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }


    }
}
