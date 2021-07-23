using System;

namespace SalesApplication
{
    class MainMenu
    {
        public void showMainMenu()
        {
            string input;
            bool retry = true;
            while (retry)
            {
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
                    Console.Clear();
                    ReportsMenu reportsMenu = new ReportsMenu();
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


    }
}
