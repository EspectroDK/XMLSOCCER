using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSoccerCOM
{
    class InvalidIDException : Exception
    {
        public InvalidIDException()
        {

        }

        public InvalidIDException(string message)
             :base(message)
        {
        }

        public InvalidIDException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
