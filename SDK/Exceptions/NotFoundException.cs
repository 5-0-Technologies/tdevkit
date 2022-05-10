using System;

namespace SDK.Exceptions
{
    public class NotFoundException : Exception
    {
        public const string message = "The target was not found.";

        public NotFoundException()
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
