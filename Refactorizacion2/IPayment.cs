using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    public interface IPayment
    {
        Message Pay(decimal amount, Card card, string password);
    }
}
