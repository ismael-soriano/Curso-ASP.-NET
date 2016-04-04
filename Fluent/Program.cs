using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            foo.Select().Where();
        }
    }
}
