using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    public class Card
    {
        public string CCC { get; set; }
        public string PrivateKey { get; protected set; }
        public TipoTarjeta TipoTarjeta { get; protected set; }
    }
}
