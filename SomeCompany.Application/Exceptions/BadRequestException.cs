using System;

namespace SomeCompany.Application.Exceptions
{
    /// <summary>
    /// Base exception for bad requests
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException()
        { }

        public BadRequestException(string message)
            :base(message)
        { }
    }
}
