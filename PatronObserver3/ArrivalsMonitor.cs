using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver3
{
    public class ArrivalsMonitor : IObserver<BaggageInfo>
    {
        private string _name;
        private List<string> _flightInfos = new List<string>();
        private IDisposable _cancellation;
        private string _fmt = "{0,-20} {1,5}  {2, 3}";

        public ArrivalsMonitor(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("The observer must be assigned a name.");

            _name = name;
        }

        public virtual void Subscribe(BaggageHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            _flightInfos.Clear();
        }

        public virtual void OnCompleted()
        {
            _flightInfos.Clear();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public virtual void OnNext(BaggageInfo info)
        {
            bool updated = false;

            // Flight has unloaded its baggage; remove from the monitor.
            if (info.Carousel == 0)
                RemoveFlight(info);

            else
                addFlight(info);

            if (updated)
                PrintFlightsInfo();
        }

        private bool RemoveFlight(BaggageInfo info)
        {
            var updated = false;
            var flightsToRemove = new List<string>();
            string flightNo = String.Format("{0,5}", info.FlightNumber);

            foreach (var flightInfo in _flightInfos)
            {
                if (flightInfo.Substring(21, 5).Equals(flightNo))
                {
                    flightsToRemove.Add(flightInfo);
                    updated = true;
                }
            }

            foreach (var flightToRemove in flightsToRemove)
                _flightInfos.Remove(flightToRemove);

            flightsToRemove.Clear();

            return updated;
        }

        private bool addFlight(BaggageInfo info)
        {
            var updated = false;
            // Add flight if it does not exist in the collection.
            string flightInfo = String.Format(_fmt, info.From, info.FlightNumber, info.Carousel);
            if (!_flightInfos.Contains(flightInfo))
            {
                _flightInfos.Add(flightInfo);
                updated = true;
            }

            return updated;
        }

        private void PrintFlightsInfo()
        {
            _flightInfos.Sort();
            Console.WriteLine("Arrivals information from {0}", this._name);
            foreach (var flightInfo in _flightInfos)
                Console.WriteLine(flightInfo);

            Console.WriteLine();
        }
    }
}
