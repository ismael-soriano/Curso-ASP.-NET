using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver3
{
    public class BaggageInfo
    {
        private int flightNo;
        public int FlightNumber
        {
            get { return this.flightNo; }
        }

        private string origin;
        public string From
        {
            get { return this.origin; }
        }

        private int location;
        public int Carousel
        {
            get { return this.location; }
        }

        internal BaggageInfo(int flight, string from, int carousel)
        {
            this.flightNo = flight;
            this.origin = from;
            this.location = carousel;
        }
    }
}
