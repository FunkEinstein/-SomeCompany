namespace SomeCompany.Application.Exceptions
{
    public class DepartmentNotFoundException : NotFoundException
    {
        public DepartmentNotFoundException(int departmentId) 
            : base($"Department with id:{departmentId} doesn't found.")
        { }
    }
}
