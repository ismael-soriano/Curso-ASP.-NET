using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    public interface IController
    {
        void CheckValue(object sender, PropertyChangeEvent e);
    }
}
