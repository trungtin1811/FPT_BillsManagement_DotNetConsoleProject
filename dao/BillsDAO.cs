using ElectricityBillsManagement.constant;
using ElectricityBillsManagement.model;
using ElectricityBillsManagement.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillsManagement.dao
{
    public class BillsDAO
    {
        private static BillsDAO instance = null;
        private static readonly object instanceLock = new object();
        private List<Bills> bills;

        public BillsDAO()
        {
            bills = new List<Bills>();
        }
        public static BillsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BillsDAO();
                    }
                    return instance;
                }
            }
        }
        public void AddNew()
        {
            try
            {
                int choice = IOUtils.GetInt(1, 2, "Choose type of customer:\n\t1. Local Customer\t2. Foreign Customer\nYour choice: ");
                Console.WriteLine();
                string customerID = IOUtils.GetString("+ Input Customer ID: ", "Customer ID cannot be empty");
                string customerFullName = IOUtils.GetString("+ Input Customer Full Name: ", "Customer Full Name cannot be empty");
                string customerAddress = IOUtils.GetString("+ Input Customer Address: ", "Customer Address cannot be empty");
                switch (choice)
                {
                    case 1:
                        {
                            string? customerType = getType();
                            if (customerType == null)
                            {
                                throw new Exception();
                            }
                            double consumedPower = IOUtils.GetDouble(0, "+ Input Consumed Power: ");
                            double unitPrice = IOUtils.GetDouble(0, "+ Input Unit Price: ");
                            double quota = IOUtils.GetDouble(0, "+ Input Quota: ");
                            Bills bill = new LocalCustomerBills(customerID, customerFullName, customerAddress, customerType, consumedPower, unitPrice, quota);
                            bills.Add(bill);
                            break;
                        }
                    case 2:
                        {
                            string nationality = IOUtils.GetString("+ Input Nationality: ", "Nationality cannot be empty");
                            double consumedPower = IOUtils.GetDouble(0, "+ Input Consumed Power: ");
                            double unitPrice = IOUtils.GetDouble(0, "+ Input Unit Price: ");
                            Bills bill = new ForeignCustomerBills(customerID, customerFullName, customerAddress, nationality, consumedPower, unitPrice);
                            bills.Add(bill);
                            break;
                        }
                }
                Console.WriteLine();
                Console.WriteLine("Added successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Added fail!");
            }

        }

        public void DisplayAll()
        {
            Console.WriteLine();

            if (bills.Count == 0)
            {
                Console.WriteLine("No bills!");
            }
            else
            {
                Console.WriteLine($"|{"C.ID",-4}|{"C.FULL NAME",-15}|{"C.ADDRESS",-15}|{"C.TYPE",-10}|{"NATIONALITY",-15}|{"CONSUMED POWER",-15}|{"UNIT PRICE",-10}|{"QUOTA",-10}|{"TOTAL PRICE",-12}|");
                bills.ForEach(b => { b.Display(); });
            }

            Console.WriteLine();
        }

        public void GetTotalConsumedPowerByCustomerType()
        {
            Console.WriteLine();

            Console.WriteLine("Total Consumed Power by Customer type:");

            Enum.GetNames(typeof(CustomerType)).ToList().ForEach(type =>
            {
                var sum = bills
                            .Where(b => (b.GetType().Name.Equals("LocalCustomerBills") && ((LocalCustomerBills)b).CustomerType.Equals(type)))
                            .Sum(b => ((LocalCustomerBills)b).ConsumedPower);
                Console.WriteLine($"+ {type}: {sum}");
            });

            Console.WriteLine();
        }

        public void GetAVGTotalPriceOfForeignCustomer()
        {
            Console.WriteLine();

            Console.WriteLine("Average Total Price of Foreign customer:");
            if (bills.Count == 0)
            {
                Console.WriteLine($"AVG TOTAL: 0");
            }
            else
            {
                var avg = bills
                .Where(b => (b.GetType().Name.Equals("ForeignCustomerBills")))
                .Average(b => ((ForeignCustomerBills)b).TotalPrice);
                Console.WriteLine($"AVG TOTAL: {avg}");
            }

            Console.WriteLine();
        }


        private string? getType()
        {
            int choice = IOUtils.GetInt(1, 3, "+ Choose Customer type: \n\t1. LIVING\t2. BUSINESS\t3. PRODUCTION\nYour choice: ");
            switch (choice)
            {
                case 1:
                    {
                        return "LIVING";
                    }
                case 2:
                    {
                        return "BUSINESS";
                    }
                case 3:
                    {
                        return "PRODUCTION";
                    }
            }
            return null;
        }
    }
}
