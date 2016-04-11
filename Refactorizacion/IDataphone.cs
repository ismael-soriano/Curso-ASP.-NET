using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    interface IDataphone
    {
        void InsertCard(ICreditCard card);
        void Pay(int amount);
    }
}
