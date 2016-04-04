using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
    class Foo : IFluent
    {
        public IFluent Select()
        {
            return this;
        }

        public IFluent Where()
        {
            return this;
        }
    }
}
