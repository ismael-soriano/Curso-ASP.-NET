using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver3
{
    public class BaggageHandler : IObservable<BaggageInfo>
    {
        private List<IObserver<BaggageInfo>> _observers;
        private List<BaggageInfo> _flights;

        public BaggageHandler()
        {
            _observers = new List<IObserver<BaggageInfo>>();
            _flights = new List<BaggageInfo>();
        }

        public IDisposable Subscribe(IObserver<BaggageInfo> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                ProvideExistingData(observer);
            }
            return new Unsubscriber<BaggageInfo>(_observers, observer);
        }

        private void ProvideExistingData(IObserver<BaggageInfo> observer)
        {
            foreach (var item in _flights)
                observer.OnNext(item);
        }

        // Called to indicate all baggage is now unloaded.
        public void BaggageStatus(int flightNo)
        {
            BaggageStatus(flightNo, String.Empty, 0);
        }

        public void BaggageStatus(int flightNo, string from, int carousel)
        {
            var info = new BaggageInfo(flightNo, from, carousel);

            // Carousel is assigned, so add new info object to list.
            if (carousel > 0 && !_flights.Contains(info))
            {
                _flights.Add(info);
                NotifyObservers(info);
            }
            else if (carousel == 0)
            {
                // Baggage claim for flight is done
                var flightsToRemove = new List<BaggageInfo>();
                foreach (var flight in _flights)
                {
                    if (info.FlightNumber == flight.FlightNumber)
                    {
                        flightsToRemove.Add(flight);
                        NotifyObservers(info);
                    }
                }
                foreach (var flightToRemove in flightsToRemove)
                    _flights.Remove(flightToRemove);

                flightsToRemove.Clear();
            }
        }

        private void NotifyObservers(BaggageInfo info)
        {
            foreach (var observer in _observers)
                observer.OnNext(info);
        }

        public void LastBaggageClaimed()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }

        private class Unsubscriber<BaggageInfo> : IDisposable
        {
            private List<IObserver<BaggageInfo>> _observers;
            private IObserver<BaggageInfo> _observer;

            internal Unsubscriber(List<IObserver<BaggageInfo>> observers, IObserver<BaggageInfo> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
