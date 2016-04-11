using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    public class Visa : Card
    {
        public Visa()
        {
            TipoTarjeta = TipoTarjeta.Visa;
            PrivateKey = "1111";
        }
    }
}
