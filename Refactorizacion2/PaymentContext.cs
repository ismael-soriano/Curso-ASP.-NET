using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorizacion2
{
    public class PaymentContext
    {
        readonly IPayment _payment;
        readonly Action<Message> _callback;

        public PaymentContext(IPayment payment, Action<Message> callback)
        {
            if (null == payment)
                throw new ArgumentNullException("payment");

            _payment = payment;
            _callback = callback;
        }

        public void Pay(decimal amount, Card card, string password)
        {
            var message = _payment.Pay(amount, card, password);
            if (null != _callback)
                _callback(message);
        }
    }
}
