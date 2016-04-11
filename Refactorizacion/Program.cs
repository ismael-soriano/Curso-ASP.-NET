using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditcardFactory factory = new CreditCardFactory();
            var dataphone = new Dataphone();
            Pay(dataphone, 1000);

            dataphone.InsertCard(factory.GetMastercard("202020"));
            Pay(dataphone, 1000);

            dataphone.InsertCard(factory.GetVisa("22222", "abc"));
            Pay(dataphone, 1000);
            Pay(dataphone, 23);

            Console.ReadLine();
        }

        public static void Pay(Dataphone dataphone, int amount)
        {
            try
            {
                dataphone.Pay(amount);
                Console.WriteLine(String.Format("El pago de {0} se ha realizado con exito.", amount));
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("El pago no ha podido realizarse porque: {0}", e.Message));
            }
        }
    }
}
