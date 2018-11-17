using MediatR;

namespace SomeCompany.Application.Departments.Add
{
    public class AddDepartmentCommand : IRequest<int>
    {
        public string DepartmentName { get; set; }
    }
}
