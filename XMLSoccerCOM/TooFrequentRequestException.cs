using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    public class TooFrequentRequestException : Exception
    {
        public TooFrequentRequestException()
        {

        }

        public TooFrequentRequestException(string message)
             :base(message)
        {
        }

        public TooFrequentRequestException(string message, Exception inner)
        : base(message, inner)
        {
        }

    }
}
