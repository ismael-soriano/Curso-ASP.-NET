using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobrecarga
{
    public class Lasania : Alimento
    {
        const int TEMP_COCCION = 120;

        public Lasania()
        {
            TemperaturaCoccion = TEMP_COCCION;
        }
    }
}
