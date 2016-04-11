using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    public class Mastercard : ICreditCard
    {
        const int maxImport = 23;
        public string Ccc { get; private set; }

        public Mastercard(string ccc)
        {
            Ccc = ccc;
        }

        public void Pay(int amount)
        {
            Pagar(amount, Ccc);
        }

        private void Pagar(int importe, string CCC)
        {
            if (importe > maxImport)
                throw new Exception(String.Format("El importe {0} es mayor que {1}.", importe, maxImport));
        }
    }
}
