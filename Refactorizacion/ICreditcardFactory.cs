using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    public interface ICreditcardFactory
    {
        ICreditCard GetVisa(params object[] cardData);
        ICreditCard GetMastercard(params object[] cardData);
    }
}
