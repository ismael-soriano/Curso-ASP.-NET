using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    class FactoryPayment
    {
        public static IPayment GetPayment(Card card)
        {
            if (card.TipoTarjeta == TipoTarjeta.Mastercard)
                return new PaymentMastercard();

            return new PaymentVisa();
        }
    }
}
