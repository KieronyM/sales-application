using System;

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

        public void SelectSalesData(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{"Sale ID",-10} {"Product Name",-15} {"Quantity",10} {"Price",15} {"Sale Date",20}");
                Console.ResetColor();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader.GetInt32(0),-10} {dataReader.GetString(1),-15} {dataReader.GetInt32(2),10} {dataReader.GetDecimal(3).ToString("C2"),15} {dataReader.GetDateTime(4).ToString("yyyy/MM/dd"),20}");
                }
                dataReader.Close();
                this.CloseConnection();
                Console.WriteLine("\nQuery finished. Press any key to return to the reports menu...");
                Console.ReadKey();
            }
        }
        public void SelectSalesDataByYear(string year)
        {
            Console.Clear();
            Console.WriteLine("Showing all sales in " + year + "\n");
            string query = $"SELECT * FROM sales where YEAR(sale_Date) = {year}";
            SelectSalesData(query);            
        }

        public void SelectSalesDataByYearAndMonth(string year, int month)
        {
            Console.Clear();
            Console.WriteLine("Showing all sales from "+ month + "/" + year + "\n");
            string query = $"SELECT * FROM sales where YEAR(sale_Date) = {year} and MONTH(sale_Date) = {month}";
            SelectSalesData(query);
        }

        public void CountSalesData(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Total Sales:");
                Console.ResetColor();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader.GetInt32(0)}");
                }
                dataReader.Close();
                this.CloseConnection();
                Console.WriteLine("\nQuery finished. Press any key to return to the reports menu...");
                Console.ReadKey();
            }
        }

        public void CountSalesDataByYear(string year)
        {
            Console.Clear();
            Console.WriteLine("Showing total sales in " + year + "\n");
            string query = $"select COUNT(saleID) FROM sales where YEAR(sale_Date) = {year}";
            CountSalesData(query);
        }

        public void CountSalesDataByYearAndMonth(string year, int month)
        {
            Console.Clear();
            Console.WriteLine("Showing total sales from " + month + "/" + year + "\n");
            string query = $"select COUNT(saleID) FROM sales where YEAR(sale_Date) = {year} and MONTH(sale_Date) = {month}";
            CountSalesData(query);
        }

    }
}