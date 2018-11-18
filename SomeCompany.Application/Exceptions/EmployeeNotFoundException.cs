namespace SomeCompany.Application.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int employeeId) 
            : base($"Employee with id:{employeeId} doesn't found.")
        { }
    }
}
