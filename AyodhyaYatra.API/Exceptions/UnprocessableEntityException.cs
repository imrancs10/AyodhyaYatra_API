using System;

namespace AyodhyaYatra.API.Exceptions
{

    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException(string message = "Unprocessable Entity!") : base(message)
        {
        }
    }
}