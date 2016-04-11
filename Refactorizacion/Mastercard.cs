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
        public string Password { get; private set; }

        public Mastercard(string ccc, string password)
        {
            Ccc = ccc;
            Password = password;
        }

        public void Pay(int amount)
        {
            Consignar(amount, Ccc, Password);
        }

        private void Consignar(int importe, string CCC, string contraseña)
        {
            if (importe > maxImport)
                throw new Exception(String.Format("El importe {0} es mayor que {1}.", importe, maxImport));
        }
    }
}
