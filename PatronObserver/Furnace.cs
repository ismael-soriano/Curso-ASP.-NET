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
        private const string PROP_HUMIDITY = "Humidity";

        private int _temperature;
        public int Temperature
        {
            get
            {
                return _temperature;
            }

            set
            {

                OnPropertyChanged(new PropertyChangeEvent(PROP_TEMP, _temperature, value));
                _temperature = value;

            }
        }

        private int _humidity;
        public int Humidity
        {
            get
            {
                return _humidity;
            }

            set
            {
                OnPropertyChanged(new PropertyChangeEvent(PROP_HUMIDITY, _humidity, value));
                _humidity = value;
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangeEvent e)
        {
            var handler = PropertyEvent;
            if (null != handler)
                handler(this, e);
        }

        public override string ToString()
        {
            return String.Format("Horno: {0} Cº, Humedad {1}%\n", Temperature, Humidity);
        }
    }
}
