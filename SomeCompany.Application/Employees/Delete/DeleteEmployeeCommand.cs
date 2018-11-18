using MediatR;

namespace SomeCompany.Application.Employees.Delete
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
