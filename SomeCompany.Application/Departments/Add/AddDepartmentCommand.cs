using MediatR;
using SomeCompany.Application.Departments.Dto;

namespace SomeCompany.Application.Departments.Add
{
    public class AddDepartmentCommand : IRequest<int>
    {
        public DepartmentDto Department { get; }

        public AddDepartmentCommand(DepartmentDto department)
        {
            Department = department;
        }
    }
}
