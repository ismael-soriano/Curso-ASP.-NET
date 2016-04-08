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
            Pay(factory.GetMastercard("202020"), 1000);
            Pay(factory.GetVisa("22222", "abc"), 1000);

            Console.ReadLine();
        }

        public static void Pay(ICreditCard card, int quantity)
        {
            try
            {
                card.Pay(quantity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
