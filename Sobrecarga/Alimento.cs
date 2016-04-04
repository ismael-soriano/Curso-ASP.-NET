using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobrecarga
{
    public class Alimento
    {
        public int TemperaturaCoccion { get; protected set; }

        public static Alimento operator +(Alimento a1, Alimento a2)
        {
            return new Alimento() { TemperaturaCoccion = a1.TemperaturaCoccion + a2.TemperaturaCoccion };
        }

        public static Alimento operator +(Alimento a, int num)
        {
            return new Alimento() { TemperaturaCoccion = a.TemperaturaCoccion + num };
        }

        public static Alimento operator +(int num, Alimento a)
        {
            return a + num;
        }

        public static Alimento operator -(Alimento a1, Alimento a2)
        {
            var result = a1.TemperaturaCoccion - a2.TemperaturaCoccion;
            return new Alimento() { TemperaturaCoccion = result < 0 ? 0 : result };
        }

        public static Alimento operator -(Alimento a, int num)
        {
            var result = a.TemperaturaCoccion - num;
            return new Alimento() { TemperaturaCoccion = result < 0 ? 0 : result };
        }

        public static Alimento operator -(int num, Alimento a)
        {
            return a - num; 
        }

        public override string ToString()
        {
            return String.Format("Temperatura de cocción: {0}", TemperaturaCoccion);
        }
    }
}
