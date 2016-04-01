using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class MyEvent
    {
        public bool MyData { get; private set; }
        public int SecondParams { get; private set; }

        public MyEvent(bool myData)
        {
            MyData = myData;
        }

        public MyEvent(bool myData, int secondParams)
            : this(myData)
        {
            SecondParams = secondParams;
        }
    }
}
