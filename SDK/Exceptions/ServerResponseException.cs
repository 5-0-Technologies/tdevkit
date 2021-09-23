using System;

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
