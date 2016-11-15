using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    class InvalidAPIKeyException : Exception
    {
        public InvalidAPIKeyException()
        {

        }

        public InvalidAPIKeyException(string message)
             :base(message)
        {
        }

        public InvalidAPIKeyException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
