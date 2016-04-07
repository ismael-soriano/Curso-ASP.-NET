using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    class Program
    {
        static void Main(string[] args)
        {
            Furnace furnace = new Furnace();

            var controller = new Controller("Controller 1", 150);
            var controller2 = new Controller("Controller 2", 200);

            furnace.PropertyEvent += controller.CheckValue;
            ChangeTemperature(furnace, 120);
            ChangeTemperature(furnace, 200);
            furnace.PropertyEvent -= controller.CheckValue;

            furnace.PropertyEvent += controller2.CheckValue;
            ChangeTemperature(furnace, 300);

            furnace.PropertyEvent += controller.CheckValue;
            ChangeTemperature(furnace, 800);

            Console.ReadLine();
        }

        private static void ChangeTemperature(Furnace furnace, int temperature)
        {
            furnace.Temperature = temperature;
            PrintStatus(furnace);
        }

        private static void PrintStatus(Furnace furnace)
        {
            Console.WriteLine(String.Format("Temperatura Horno: {0}\n", furnace.Temperature));
        }
    }
}
