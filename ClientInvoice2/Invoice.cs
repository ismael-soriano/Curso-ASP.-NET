using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInvoice2
{
    public class Invoice : EntityBase
    {
        public Customer Customer { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, Customer: {1}, Amount: {2}", Id, Customer.Name, Amount);
        }
    }
}
