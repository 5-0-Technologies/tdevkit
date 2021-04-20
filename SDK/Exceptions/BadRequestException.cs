using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Exceptions
{
    public class BadRequestException : Exception
    {
        public const string message = "There was a problem with the request.";

        public BadRequestException()
        {

        }

        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
