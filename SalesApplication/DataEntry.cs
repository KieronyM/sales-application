using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class DataEntry
    {
        public DataEntry()
        {
            Console.WriteLine("Enter product name:");
            string product_Name = Console.ReadLine();
            bool retry = true;
            int quantity = 0;
            while (retry)
            {
                Console.WriteLine("Enter quantity sold:");
                if (int.TryParse(Console.ReadLine(), out quantity))
                {
                    retry = false;
                }
                else
                {
                    Console.WriteLine("That was not a valid quantity. Press any key to try again");
                    Console.ReadKey();
                }
            }
            retry = true;
            decimal price = 0;
            while (retry)
            {
                Console.WriteLine("Enter price:");
                if (decimal.TryParse(Console.ReadLine(), out price))
                {
                    price = Math.Round(price, 2);
                    retry = false;
                }
                else
                {
                    Console.WriteLine("That was not a valid price. Press any key to try again");
                    Console.ReadKey();
                }
            }
            retry = true;
            DateTime sales_Date = DateTime.Now;
            string formatted_sales_Date = "";
            while (retry)
            {
                Console.WriteLine("Enter sale date in any valid date format or leave blank for todays date:");
                string dateInput = Console.ReadLine();
                if (dateInput != "")
                {
                     if (DateTime.TryParse(dateInput, out sales_Date))
                    {
                        formatted_sales_Date = sales_Date.ToString("yyyy/MM/dd");
                        retry = false;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid date.  Press any key to try again");
                        Console.ReadKey();
                    }
                }
                else
                {
                    formatted_sales_Date = sales_Date.ToString("yyyy/MM/dd");
                    retry = false;
                }
                
            }
            Console.Clear();
            Console.WriteLine("---------- Sale Record Details ----------");
            Console.WriteLine("Product Name: " + product_Name);
            Console.WriteLine("Quantity: " + quantity);
            Console.WriteLine("Price: " + price.ToString("C2"));
            Console.WriteLine("Date of Sale: " + formatted_sales_Date + "\n");
            Console.WriteLine("Press Enter to save this record to the database, or any key to quit without making changes");
            //var menuOption = Console.ReadKey();
            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
                MySQLService db = new MySQLService();
                db.InsertSalesData(product_Name, quantity, price, formatted_sales_Date);
            }
            else
            {
                Console.WriteLine("ABORT!");
            }
            //
        }
    }
}
