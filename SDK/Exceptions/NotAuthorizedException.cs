﻿using System;

namespace SDK.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public const string message = "You have not been authorized yet.";

        public NotAuthorizedException()
        {

        }
        public NotAuthorizedException(string message) : base(message)
        {

        }
        public NotAuthorizedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
