using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();

            for (var i = 0; i <= 100000; i++)
                sb.Append(i);

            Console.Write(sb);
            Console.ReadLine();
        }
    }
}
