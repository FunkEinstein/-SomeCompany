using MediatR;
using SomeCompany.Application.Departments.ResponseDto;

namespace SomeCompany.Application.Departments.Get
{
    public class GetDepartmentQuery : IRequest<DepartmentInfoDto>
    {
        public int Id { get; }

        public GetDepartmentQuery(int id)
        {
            Id = id;
        }
    }
}
