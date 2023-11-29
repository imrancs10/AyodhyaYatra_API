using System;

namespace KaashiYatra.API.Exceptions
{

    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException(string message = "Unprocessable Entity!") : base(message)
        {
        }
    }
}