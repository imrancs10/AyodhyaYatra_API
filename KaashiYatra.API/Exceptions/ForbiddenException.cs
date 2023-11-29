﻿using System;

namespace KaashiYatra.API.Exceptions
{

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message = "You are forbidden to access this resource!") : base(message)
        {
        }
    }
}