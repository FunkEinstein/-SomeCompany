using MediatR;
using SomeCompany.Application.Departments.ResponseDto;

namespace SomeCompany.Application.Departments.Get
{
    public class GetAllDepartmentsQuery : IRequest<AllDepartmentsDto>
    {
        public int Page { get; set; }
        public int RowsOnPage { get; set; }
        public string NameFilter { get; set; }
    }
}
