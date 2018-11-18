namespace SomeCompany.Application.Exceptions
{
    public class EmailAlreadyExistException : AlreadyExistException
    {
        public EmailAlreadyExistException(string email) 
            : base($"Email {email} is already exist")
        { }
    }
}
