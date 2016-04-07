using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver1
{
    public class PropertyChangeEvent
    {
        public string Property { get; private set; }
        public int OldValue { get; private set; }
        public int NewValue { get; private set; }

        public PropertyChangeEvent(string property, int oldValue, int newValue)
        {
            Property = property;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
