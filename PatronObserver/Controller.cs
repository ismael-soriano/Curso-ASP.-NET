using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    public class Controller : IController
    {
        private string _instName;
        private int _maxTemperature;

        public Controller(string controllerName, int maxTemperature)
        {
            _instName = controllerName;
            _maxTemperature = maxTemperature;
        }

        public void CheckValue(object sender, PropertyChangeEvent e)
        {
            if (e.NewValue > _maxTemperature)
                throw new PropertyVetoException(String.Format("{0}: Se ha vetado un cambio de {1} a {2} porque sobrepasa el máximo de {3}.", _instName, e.OldValue, e.NewValue, _maxTemperature));
        }
    }
}
