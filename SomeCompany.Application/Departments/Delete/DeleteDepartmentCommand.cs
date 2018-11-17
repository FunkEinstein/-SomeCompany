using MediatR;

namespace SomeCompany.Application.Departments.Delete
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int Id { get; }

        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
