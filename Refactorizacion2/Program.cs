using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    public enum TipoTarjeta
    {
        Visa,
        Mastercard
    }

    class Program
    {
        static void Main(string[] args)
        {
            var card = new Visa() { CCC = "1234" };
            var payment = FactoryPayment.GetPayment(card);
            var context = new PaymentContext(payment, Write);
            context.Pay(1000, card, "2222");
        }

        static void Write(Message message)
        {
            if (null != message)
                Console.WriteLine(message.Text);

            Console.ReadLine();
        }
    }
}
