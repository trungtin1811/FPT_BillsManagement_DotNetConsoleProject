using ElectricityBillsManagement.dao;
using ElectricityBillsManagement.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ElectricityBillsManagement
{
    public class Program
    {
        static void Main()
        {
            int choice;
            do
            {
                printMenu();
                choice = IOUtils.GetInt(1, 5, "Enter your choice: ");
                switch (choice)
                {
                    case 1:
                        {
                            BillsDAO.Instance.AddNew();
                            Console.WriteLine("~~~~~~ Press any key to back to menu ~~~~~~");
                            ConsoleKeyInfo? key = Console.ReadKey(false);
                            if (key != null)
                            {
                                IOUtils.ChangeColor("Back to menu! Please wait 2 seconds", ConsoleColor.Blue);
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                    case 2:
                        {
                            BillsDAO.Instance.DisplayAll();
                            Console.WriteLine("~~~~~~ Press any key to back to menu ~~~~~~");
                            ConsoleKeyInfo? key = Console.ReadKey(false);
                            if (key != null)
                            {
                                IOUtils.ChangeColor("Back to menu! Please wait 2 seconds", ConsoleColor.Blue);
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                    case 3:
                        {
                            BillsDAO.Instance.GetTotalConsumedPowerByCustomerType();
                            Console.WriteLine("~~~~~~ Press any key to back to menu ~~~~~~");
                            ConsoleKeyInfo? key = Console.ReadKey(false);
                            if (key != null)
                            {
                                IOUtils.ChangeColor("Back to menu! Please wait 2 seconds", ConsoleColor.Blue);
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                    case 4:
                        {
                            BillsDAO.Instance.GetAVGTotalPriceOfForeignCustomer();
                            Console.WriteLine("~~~~~~ Press any key to back to menu ~~~~~~");
                            ConsoleKeyInfo? key = Console.ReadKey(false);
                            if (key != null)
                            {
                                IOUtils.ChangeColor("Back to menu! Please wait 2 seconds", ConsoleColor.Blue);
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                    case 5:
                        {
                            IOUtils.ChangeColor("Bye bye!!!~~\nSee you again!!~~~", ConsoleColor.Blue);
                            Thread.Sleep(2000);
                            break;
                        }
                }
            } while (choice != 5);

        }

        public static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("**************************************************************");
            Console.WriteLine("*   Welcome to Bills Management System                       *");
            Console.WriteLine("*   Select the option bellow (1 ~ 5):                        *");
            Console.WriteLine("*   1. Add new bill.                                         *");
            Console.WriteLine("*   2. Show all bill.                                        *");
            Console.WriteLine("*   3. Get total Consumed Power By Customer type.            *");
            Console.WriteLine("*   4. Get AVG total price of Foreign Customer.              *");
            Console.WriteLine("*   5. Quit.                                                 *");
            Console.WriteLine("**************************************************************");
        }
    }
}
