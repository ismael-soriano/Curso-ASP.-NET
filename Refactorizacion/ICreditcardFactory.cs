using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    public interface ICreditcardFactory
    {
        ICreditCard GetMastercard(string ccc);
        ICreditCard GetVisa(string ccc, string password);
    }
}
