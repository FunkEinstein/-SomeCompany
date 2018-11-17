using MediatR;
using SomeCompany.Application.Departments.Dto;

namespace SomeCompany.Application.Departments.Get
{
    public class GetAllDepartmentsQuery : IRequest<AllDepartmentsDto>
    { }
}
