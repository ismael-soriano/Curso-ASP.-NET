using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    public class CreditCardFactory : ICreditcardFactory
    {
        public ICreditCard GetCard(Type cardType, params object[] args)
        {
            return Activator.CreateInstance(cardType, args) as ICreditCard;
        }
    }
}
