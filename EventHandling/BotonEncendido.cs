using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class BotonEncendido
    {
        public event MyEventHandler MyEvent;
        private bool _onOff;

        public void BotonTelevisor()
        {
            _onOff = !_onOff;
            OnMyEvent(new MyEvent(_onOff));
        }

        protected virtual void OnMyEvent(MyEvent e)
        {
            var handler = MyEvent;
            if (null != handler)
                handler(this, e);
        }
    }
}
