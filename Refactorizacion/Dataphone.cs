using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion
{
    class Dataphone : IDataphone
    {
        ICreditCard _card;

        public void InsertCard(ICreditCard card)
        {
            if (null == card)
                throw new ArgumentNullException("card");

            _card = card;
        }

        public void Pay(int amount)
        {
            if (null == _card)
                throw new NullReferenceException("No hay ninguna tarjeta insertada");

            _card.Pay(amount);
        }

    }
}
