using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    public interface IFurnaceFactory
    {
        Furnace GetFurnace();
        IController GetController(string controllerName, int maxTemperature);
    }
}
