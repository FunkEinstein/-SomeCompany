using MediatR;
using SomeCompany.Application.Employees.ResponseDto;

namespace SomeCompany.Application.Employees.Get
{
    public class GetEmployeeQuery : IRequest<EmployeeInfoDto>
    {
        public int Id { get; }

        public GetEmployeeQuery(int id)
        {
            Id = id;
        }
    }
}
