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
        static Furnace furnace;

        static void Main(string[] args)
        {
            IFurnaceFactory factory = new FurnaceFactory();
            furnace = factory.GetFurnace();

            var controller = new Controller("Controller 1", 150);
            var controller2 = new Controller("Controller 2", 200);

            furnace.PropertyEvent += controller.CheckValue;
            ChangeTemperature(120);
            ChangeTemperature(200);
            furnace.PropertyEvent -= controller.CheckValue;

            furnace.PropertyEvent += controller2.CheckValue;
            ChangeTemperature(300);

            Console.ReadLine();
        }

        private static void ChangeTemperature(int temperature)
        {
            furnace.Temperature = temperature;
            Console.WriteLine(String.Format("Temperatura Horno: {0}\n", furnace.Temperature));
        }
    }
}
