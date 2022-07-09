using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillsManagement.model
{
    public class LocalCustomerBills : Bills
    {
        public string CustomerType;
        public double ConsumedPower;
        public double UnitPrice;
        public double Quota;
        public double TotalPrice;

        public LocalCustomerBills(string customerID, string customerFullName, string customerAddress, string customerType, double consumedPower, double unitPrice, double quota) : base(customerID, customerFullName, customerAddress)
        {
            CustomerType = customerType;
            ConsumedPower = consumedPower;
            UnitPrice = unitPrice;
            Quota = quota;
            TotalPrice = consumedPower < quota ? consumedPower * unitPrice : consumedPower * unitPrice * quota + (consumedPower - quota) * unitPrice;
        }
        public LocalCustomerBills()
        {

        }

        public override void Display()
        {
            Console.WriteLine($"|{CustomerID,-4}|{CustomerFullName,-15}|{CustomerAddress,-15}|{CustomerType,-10}|{"-",-15}|{ConsumedPower,-15}|{UnitPrice,-10}|{Quota,-10}|{TotalPrice,-12}|");
        }
    }
}
