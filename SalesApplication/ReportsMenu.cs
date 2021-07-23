using System;

namespace SalesApplication
{
    class ReportsMenu
    {
        public ReportsMenu()
        {
            string input;
            bool retry = true;
            while (retry)
            {
                Console.WriteLine("----- Sales Report Application - Version 1.0 -----");
                Console.WriteLine("------------------ REPORTS MENU ------------------");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1 - Products Sold By Year");
                Console.WriteLine("2 - Products Sold By Month");
                Console.WriteLine("3 - Total Sales By Year");
                Console.WriteLine("4 - Total Sales By Month");
                Console.WriteLine("Q - Return to Main Menu");
                input = Console.ReadLine().ToString().ToLower();
                MySQLService db = new MySQLService();
                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Enter year to filter by (e.g 2021):");
                    string year = Console.ReadLine();
                    db.SelectSalesDataByYear(year);
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Enter year to filter by (e.g 2021):");
                    string year = Console.ReadLine();
                    int month = GetMonth();
                    db.SelectSalesDataByYearAndMonth(year, month);
                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Enter year to filter by (e.g 2021):");
                    string year = Console.ReadLine();
                    db.CountSalesDataByYear(year);
                }
                else if (input == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Enter year to filter by (e.g 2021):");
                    string year = Console.ReadLine();
                    int month = GetMonth();
                    db.CountSalesDataByYearAndMonth(year, month);
                }
                else if (input == "q")
                {
                    retry = false;
                }
                else
                {
                    Console.WriteLine("Could not identify input. Press enter to retry");
                    Console.ReadLine();
                }
                Console.Clear();
            }

        }

        public int GetMonth()
        {
            Console.WriteLine("Select month to filter by:");
            Console.WriteLine("1 - January");
            Console.WriteLine("2 - February");
            Console.WriteLine("3 - March");
            Console.WriteLine("4 - April");
            Console.WriteLine("5 - May");
            Console.WriteLine("6 - June");
            Console.WriteLine("7 - July");
            Console.WriteLine("8 - August");
            Console.WriteLine("9 - September");
            Console.WriteLine("10 - October");
            Console.WriteLine("11 - November");
            Console.WriteLine("12 - December");
            int month = Convert.ToInt32(Console.ReadLine());
            return month;
        }
    }
}
