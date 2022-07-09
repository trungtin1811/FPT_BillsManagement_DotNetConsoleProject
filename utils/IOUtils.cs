using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElectricityBillsManagement.utils
{
    internal class IOUtils
    {

        public static void ChangeColor(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static int GetInt(int min, int max, string inputMsg, string errorMsg)
        {
            int n;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    n = int.Parse(Console.ReadLine());
                    if (n >= min && n <= max)
                    {
                        return n;
                    }
                    //ChangeColor(errorMsg, ConsoleColor.Red);
                    ChangeColor($"Your input must be a Integer between [{min};{max}]", ConsoleColor.Red);
                }
                catch (Exception e)
                {
                    ChangeColor(errorMsg, ConsoleColor.Red);
                }
            } while (true);

        }
        public static int GetInt(int min, int max, string inputMsg)
        {
            int n;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    n = int.Parse(Console.ReadLine());
                    if (n >= min && n <= max)
                    {
                        return n;
                    }
                    ChangeColor($"Your input must be a Integer between [{min};{max}]", ConsoleColor.Red);
                }
                catch (Exception e)
                {
                    ChangeColor($"Your input must be a Integer between [{min};{max}]", ConsoleColor.Red);
                }
            } while (true);
        }
        public static int GetInt(int min, string inputMsg)
        {
            int n;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    n = int.Parse(Console.ReadLine());
                    if (n >= min)
                    {
                        return n;
                    }
                    ChangeColor($"Your input must be a Integer >= {min}", ConsoleColor.Red);
                }
                catch (Exception e)
                {
                    ChangeColor($"Your input must be a Integer >= {min}", ConsoleColor.Red);
                }
            } while (true);
        }
        public static double GetDouble(double min, string inputMsg)
        {
            double n;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    n = double.Parse(Console.ReadLine());
                    if (n >= min)
                    {
                        return n;
                    }
                    ChangeColor($"Your input must be a Integer >= {min}", ConsoleColor.Red);
                }
                catch (Exception e)
                {
                    ChangeColor($"Your input must be a Integer >= {min}", ConsoleColor.Red);
                }
            } while (true);
        }
        public static string GetRegexString(string regex, string inputMsg, string errorMsg)
        {
            string regexString;
            do
            {
                Console.Write(inputMsg);
                regexString = Console.ReadLine();
                bool check = Regex.IsMatch(regexString.ToUpper().Trim(), regex);
                if (check)
                {
                    return regexString.ToUpper().Trim();
                }
                else
                {
                    ChangeColor(errorMsg, ConsoleColor.Red);
                }
            } while (true);
        }
        public static DateTime GetDate(string inputMsg, string errorMsg)
        {
            string date;
            DateTime dateValue;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    date = Console.ReadLine();
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    dateValue = DateTime.ParseExact(date, "mm/dd/yyyy", provider);
                    return dateValue;
                }
                catch (Exception e)
                {
                    ChangeColor(errorMsg, ConsoleColor.Red);
                }
            } while (true);
        }
        public static string GetString(string inputMsg, string errorMsg)
        {
            string s;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    s = Console.ReadLine();
                    if (s.Trim().Length != 0)
                    {
                        return s.Trim();
                    }
                }
                catch (Exception e)
                {
                    ChangeColor(errorMsg, ConsoleColor.Red);
                }
            } while (true);
        }
        public static bool GetBool(char y, char n, string inputMsg, string errorMsg)
        {
            char s;
            do
            {
                try
                {
                    Console.Write(inputMsg);
                    s = char.Parse(Console.ReadLine());
                    if (s.ToString().ToLower().Equals(y.ToString()) || s.ToString().ToLower().Equals(n.ToString()))
                    {
                        return s.ToString().ToLower().Equals(y.ToString());
                    }
                    else
                    {
                        ChangeColor(errorMsg, ConsoleColor.Red);
                    }
                }
                catch (Exception e)
                {
                    ChangeColor(errorMsg, ConsoleColor.Red);
                }
            } while (true);
        }
    }
}
