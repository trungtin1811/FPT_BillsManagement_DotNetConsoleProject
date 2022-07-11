using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillsManagement.model
{
    public class LocalCustomerBills : Bills
    {
        public string TargetedCustomer;
        public double ConsumedPower;
        public double UnitPrice;
        public double Quota;
        public double TotalPrice;

        public LocalCustomerBills(string customerID, string customerFullName, string customerAddress, string targetedCustomer, double consumedPower, double unitPrice, double quota) : base(customerID, customerFullName, customerAddress, constant.CustomerType.LOCAL.ToString())
        {
            TargetedCustomer = targetedCustomer;
            ConsumedPower = consumedPower;
            UnitPrice = unitPrice;
            Quota = quota;
            TotalPrice = consumedPower < quota ? consumedPower * unitPrice : consumedPower * unitPrice * quota + (consumedPower - quota) * unitPrice;
        }


        public override void Display()
        {
            Console.WriteLine($"|{CustomerID,-4}|{CustomerFullName,-15}|{CustomerAddress,-15}|{TargetedCustomer,-10}|{"-",-12}|{ConsumedPower,-15}|{UnitPrice,-10}|{Quota,-6}|{TotalPrice,-12}|{CustomerType,-8}|");
        }
    }
}
