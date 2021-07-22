using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace SalesApplication
{
    class MySQLService
    {
    MySqlConnection connection;
        
        public MySQLService()
        {
            Initialize();
        }

        public void Initialize()
        {
            string connectionstring = "server=sql4.freemysqlhosting.net;port=3306;user=sql4426836;password=p59pTYaf2H;database=sql4426836;SslMode=none;";
            connection = new MySqlConnection(connectionstring);
        }
        
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Clear();
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Please try again");
                        break;
                    default:
                        Console.WriteLine(ex.Message);
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void InsertSalesData(string product_name, int quantity, decimal price, string sale_Date)
        {
            string query = $"INSERT INTO sales (product_name, quantity, price, sale_Date) VALUES('{product_name}', {quantity}, {price}, '{sale_Date}')";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void SelectSalesData()
        {
            string query = "SELECT * FROM sales";
            
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{"Sale ID", -10} {"Product Name",-15} {"Quantity",10} {"Price",15} {"Sale Date",20}");
                Console.ResetColor();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader.GetInt32(0), -10} {dataReader.GetString(1),-15} {dataReader.GetInt32(2),10} {dataReader.GetDecimal(3).ToString("C2"),15} {dataReader.GetDateTime(4).ToString("yyyy/MM/dd"), 20}");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
        }

    }
}