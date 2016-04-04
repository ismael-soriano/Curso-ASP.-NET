using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobrecarga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Pan() + new Lasania());
            Console.WriteLine(new Pan() + 200);
            Console.WriteLine(200 - new Pan() + new Lasania() - 180 + new Pan());
            Console.ReadLine();
        }
    }
}