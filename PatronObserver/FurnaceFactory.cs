using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    public class FurnaceFactory : IFurnaceFactory
    {
        public Furnace GetFurnace()
        {
            return new Furnace();
        }

        public IController GetController(string controllerName, int maxTemperature)
        {
            return new Controller(controllerName, maxTemperature);
        }
    }
}
