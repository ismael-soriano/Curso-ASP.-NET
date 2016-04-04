using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobrecarga
{
    public class Pan : Alimento
    {
        const int TEMP_COCCION = 60;

        public Pan()
        {
            TemperaturaCoccion = TEMP_COCCION;
        }
    }
}
