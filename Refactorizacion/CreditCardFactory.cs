using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    public class CreditCardFactory : ICreditcardFactory
    {
        public ICreditCard GetMastercard(string ccc = "")
        {
            return new Visa(ccc);
        }

        public ICreditCard GetVisa(string ccc = "", string password = "")
        {
            return new Mastercard(ccc, password);
        }
    }
}
