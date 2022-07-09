using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillsManagement.model
{
    public class ForeignCustomerBills : Bills
    {
        public string Nationality;
        public double ConsumedPower;
        public double UnitPrice;
        public double TotalPrice;

        public ForeignCustomerBills(string customerID, string customerFullName, string customerAddress, string nationality, double consumedPower, double unitPrice) : base(customerID, customerFullName, customerAddress)
        {
            Nationality = nationality;
            ConsumedPower = consumedPower;
            UnitPrice = unitPrice;
            TotalPrice = consumedPower * unitPrice;
        }
        public ForeignCustomerBills()
        {

        }

        public override void Display()
        {
            Console.WriteLine($"|{CustomerID,-4}|{CustomerFullName,-15}|{CustomerAddress,-15}|{"-",-10}|{Nationality,-15}|{ConsumedPower,-15}|{UnitPrice,-10}|{"-",-10}|{TotalPrice,-12}|");
        }
    }
}
