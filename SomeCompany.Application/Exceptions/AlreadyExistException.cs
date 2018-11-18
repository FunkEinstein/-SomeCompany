namespace SomeCompany.Application.Exceptions
{
    public class AlreadyExistException : BadRequestException
    {
        public AlreadyExistException(string message) 
            : base(message)
        { }
    }
}
