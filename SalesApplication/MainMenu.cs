using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace SalesApplication
{
    class MainMenu
    {
        /*
        MySqlConnection con;
        MySqlCommand cmd;

        public void connectToMySQL()
        {
            string connectionstring = "server=sql4.freemysqlhosting.net;port=3306;user=sql4426836;password=p59pTYaf2H;database=sql4426836;SslMode=none;";
            con = new MySqlConnection(connectionstring);
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string row = "";
            cmd.CommandText = $"select * from sales";
            cmd.ExecuteNonQuery();
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                for (int i = 0; i < myReader.FieldCount; i++)
                {
                    row += myReader.GetName(i) + "\t";
                }
                Console.WriteLine(row);
                row = "";

                for (int i = 0; i < myReader.FieldCount; i++)
                {
                    row += myReader.GetString(i) + "\t";
                }
                Console.WriteLine(row);
                row = "";
            }
            myReader.Close();
            Console.ReadLine();
        }
        */

        public void showMainMenu()
        {
            string input;
            Console.WriteLine("----- Sales Report Application - Version 1.0 -----");
            Console.WriteLine("-------------------- MAIN MENU -------------------");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1 - Data Entry");
            Console.WriteLine("2 - Reports");
            Console.WriteLine("Q - Quit");
            input = Console.ReadLine().ToString().ToLower();
            if (input == "1")
            {
                Console.Clear();
                DataEntry d = new DataEntry();
            }
            else if (input == "2") 
            {
                MySQLService db = new MySQLService();
                db.SelectSalesData();
                Console.ReadLine();
            }
            else if (input == "q")
            {
                Console.WriteLine("q selected");
            }
            else
            {
                Console.WriteLine("Could not identify input");
            }
            Console.ReadLine();
        }


    }
}
