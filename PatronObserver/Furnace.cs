using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    public class Furnace
    {
        public event PropertyEventHandler PropertyEvent;
        private const string PROP_TEMP = "Temperature";
        
        private int _temperature;
        public int Temperature
        {
            get
            {
                return _temperature;
            }

            set
            {
                try
                {
                    OnTemperatureChanged(new PropertyChangeEvent(PROP_TEMP, _temperature, value));

                    _temperature = value;
                }
                catch (PropertyVetoException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        protected virtual void OnTemperatureChanged(PropertyChangeEvent e)
        {
            var handler = PropertyEvent;
            if (null != handler)
                handler(this, e);
        }
    }
}
