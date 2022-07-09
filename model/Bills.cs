using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillsManagement.model
{
    public class Bills
    {
        public string CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }

        public Bills(string customerID, string customerFullName, string customerAddress)
        {
            CustomerID = customerID;
            CustomerFullName = customerFullName;
            CustomerAddress = customerAddress;
        }
        public Bills()
        {

        }
        public virtual void Display()
        {

        }
    }
}
