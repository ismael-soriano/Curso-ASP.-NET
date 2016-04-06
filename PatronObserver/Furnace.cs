using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver
{
    public class Furnace : IObservable<FurnaceStatus>
    {
        public int Temperature {get; }
        private List<IObserver<FurnaceStatus>> observers; 

        public Furnace()
        {
            observers = new List<IObserver<FurnaceStatus>>();
        }

        public IDisposable Subscribe(IObserver<FurnaceStatus> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<FurnaceStatus>> _observers;
            private IObserver<FurnaceStatus> _observer;

            public Unsubscriber(List<IObserver<FurnaceStatus>> observers, IObserver<FurnaceStatus> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
