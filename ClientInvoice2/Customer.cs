using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInvoice2
{
    public class Customer : EntityBase, IComparable
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public int CompareTo(object obj)
        {
            var customer = obj as Customer;
            if (null == obj)
                return -1;

            return this.Id.CompareTo(customer.Id);
        }
    }
}
