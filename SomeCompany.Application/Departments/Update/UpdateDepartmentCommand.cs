using MediatR;

namespace SomeCompany.Application.Departments.Update
{
    public class UpdateDepartmentCommand : IRequest
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
