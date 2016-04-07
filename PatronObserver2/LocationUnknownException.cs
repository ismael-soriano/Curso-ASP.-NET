using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver2
{
    public class LocationUnknownException : Exception
    {
        private const string _errorMessage = "The location cannot be determined.";
        
        internal LocationUnknownException() : base(_errorMessage)
        {  }
    }
}
