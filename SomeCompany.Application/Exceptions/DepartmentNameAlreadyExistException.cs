namespace SomeCompany.Application.Exceptions
{
    public class DepartmentNameAlreadyExistException : AlreadyExistException
    {
        public DepartmentNameAlreadyExistException(string departmentName) 
            : base($"Department name {departmentName} is already exist")
        { }
    }
}
