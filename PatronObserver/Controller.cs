using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver
{
    class Controller : IObserver<FurnaceStatus>
    {
        private IDisposable unsubscriber;
        private int _maxTemperature;

        public Controller(int maxTemperature)
        {
            _maxTemperature = maxTemperature;
        }

        public virtual void Subscribe(IObservable<FurnaceStatus> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine();
            this.Unsubscribe();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(FurnaceStatus value)
        {
            throw new NotImplementedException();
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
