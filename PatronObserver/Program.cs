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

            var tempController = new Controller("Temperature Controller 1", 150);
            var tempController2 = new Controller("Temperature Controller 2", 200);
            var humidityController = new Controller("Humidity Controller", 40);

            furnace.PropertyEvent += tempController.CheckValue;
            furnace.PropertyEvent += humidityController.CheckValue;
            ChangeTemperature(furnace, 120);
            ChangeHumidity(furnace, 10);
            PrintStatus(furnace);

            ChangeTemperature(furnace, 200);
            ChangeHumidity(furnace, 30);
            PrintStatus(furnace);
            furnace.PropertyEvent -= tempController.CheckValue;

            furnace.PropertyEvent += tempController2.CheckValue;
            ChangeTemperature(furnace, 300);
            ChangeHumidity(furnace, 120);
            PrintStatus(furnace);

            furnace.PropertyEvent += tempController.CheckValue;
            ChangeTemperature(furnace, 800);
            ChangeHumidity(furnace, 200);
            PrintStatus(furnace);

            Console.ReadLine();
        }

        private static void ChangeTemperature(Furnace furnace, int temperature)
        {
            try
            {
                furnace.Temperature = temperature;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ChangeHumidity(Furnace furnace, int humidity)
        {
            try
            {
                furnace.Humidity = humidity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintStatus(Furnace furnace)
        {
            Console.WriteLine(furnace.ToString());
        }
    }
}
