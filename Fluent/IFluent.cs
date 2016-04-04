using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent
{
    interface IFluent
    {
        IFluent Select();
        IFluent Where();
    }
}
