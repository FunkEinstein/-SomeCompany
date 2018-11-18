using System;

namespace SomeCompany.Application.Exceptions
{
    public class NotFoundException : BadRequestException
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}
