using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class Screen
    {
        public Screen()
        {
            var botonEncendido = new BotonEncendido();

            botonEncendido.MyEvent += botonEncendido_MyEvent;
            botonEncendido.BotonTelevisor();

            botonEncendido.MyEvent -= botonEncendido_MyEvent;
            botonEncendido.BotonTelevisor();

        }

        void botonEncendido_MyEvent(object sender, MyEvent e)
        {
            Console.WriteLine(e.MyData);
        }
    }
}
