﻿using System;

namespace AyodhyaYatra.API.Exceptions
{

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message = "You are not authorized!") : base(message)
        {
        }
    }
}