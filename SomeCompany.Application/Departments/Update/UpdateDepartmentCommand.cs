using MediatR;
using SomeCompany.Application.Departments.Dto;

namespace SomeCompany.Application.Departments.Update
{
    public class UpdateDepartmentCommand : IRequest
    {
        public DepartmentDto Department { get; }

        public UpdateDepartmentCommand(DepartmentDto department)
        {
            Department = department;
        }
    }
}
