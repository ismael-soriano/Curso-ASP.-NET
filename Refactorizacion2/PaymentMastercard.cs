using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    class PaymentMastercard : IPayment
    {
        const int SALDO = 23;

        private bool VerifyPassword(Card card, string password)
        {
            return card.PrivateKey == password;
        }

        private bool VerifyAmount(decimal importe)
        {
            return importe <= SALDO;
        }

        public Message Pay(decimal amount, Card card, string password)
        {
            if (!VerifyPassword(card, password))
                return new Message() { Text = "El pin es incorrecto." };

            if (!VerifyAmount(amount))
                return new Message() { Text = "No tiene saldo." };

            return new Message() { Text = "Operación aceptada." };
        }
    }
}
