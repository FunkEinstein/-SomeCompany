using MediatR;
using SomeCompany.Application.Departments.Dto;

namespace SomeCompany.Application.Departments.Get
{
    public class GetDepartmentQuery : IRequest<DepartmentDto>
    {
        public int Id { get; }

        public GetDepartmentQuery(int id)
        {
            Id = id;
        }
    }
}
