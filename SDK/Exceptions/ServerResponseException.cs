using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Exceptions
{
    public class ServerResponseException : Exception
    {
        public const string message = "There was a problem during execution.";

        public ServerResponseException()
        {

        }

        public ServerResponseException(string message) : base(message)
        {

        }

        public ServerResponseException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
