using System;

namespace SDK.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public const string message = "There was a problem on the server side. Try again.";

        public InternalServerErrorException()
        {

        }

        public InternalServerErrorException(string message) : base(message)
        {

        }

        public InternalServerErrorException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
