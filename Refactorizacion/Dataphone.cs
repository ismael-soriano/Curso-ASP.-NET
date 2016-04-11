using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    class Dataphone
    {
        ICreditCard context;

        public Dataphone()
        {
            context = null;
        }

        public void InsertCard(ICreditCard card)
        {
            if (null == card)
                throw new ArgumentNullException("card");

            context = card;
        }

        public void Pay(int amount)
        {
            if (null == context)
                throw new NullReferenceException("No hay ninguna tarjeta insertada");

            context.Pay(amount);
        }

    }
}
