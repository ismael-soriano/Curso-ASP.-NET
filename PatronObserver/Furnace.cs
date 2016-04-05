using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver
{
    public class Furnace : IObservable<Furnace>
    {
        public IDisposable Subscribe(IObserver<Furnace> observer)
        {
            throw new NotImplementedException();
        }
    }
}
