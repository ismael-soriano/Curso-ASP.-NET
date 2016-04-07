using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    class PropertyVetoException : Exception
    {
        internal PropertyVetoException(string message) : base(message) {}
    }
}
