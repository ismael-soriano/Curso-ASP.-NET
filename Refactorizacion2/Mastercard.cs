using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    public class Mastercard : Card
    {
        public Mastercard()
        {
            TipoTarjeta = TipoTarjeta.Mastercard;
            PrivateKey = "111";
        }
    }
}
