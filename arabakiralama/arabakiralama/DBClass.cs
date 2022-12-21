using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arabakiralama
{
    internal class DBClass
    {

        private string connectionString = $"SERVER=localhost;DATABASE=arackiralama;UID=root;PASSWORD=;";

        public DataSet SelectCommand(string queryString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            
            try
            {
                connection.Open();
            }
            catch
            {
                connection.Close();
                return null;
            }

            try
            {
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(queryString, connection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch
            {
                connection.Close();
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool ExecuteCommand(string queryString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                connection.Close();
                return false;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
