using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project_P3L
{
    class dbConnection
    {
        private string connection;
        MySqlConnection conn;

        private void OpenConnection()
        {
            try
            {
                connection = "SERVER=localhost;DATABASE=pet_shop;UID=root;PASSWORD=;"; //Database Localhost
                //connection = "SERVER=192.168.19.140;DATABASE=9152;UID=pp9152;PASSWORD=9152;"; //Database Web Server Atma
                conn = new MySqlConnection(connection);
                conn.Open();
            }
            catch
            {
                throw;
            }
        }
    }
}
