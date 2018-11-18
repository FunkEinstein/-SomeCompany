using System;
using MediatR;
using SomeCompany.Application.Employees.ResponseDto;

namespace SomeCompany.Application.Employees.Get
{
    public class GetAllEmployeesQuery : IRequest<AllEmployeesDto>
    {
        public int Page { get; set; }
        public int RowsOnPage { get; set; }

        public int DepartmentId { get; set; }

        public string NameFilter { get; set; }
        public string EmailFilter { get; set; }
        public int SalaryFilter { get; set; }
        public DateTime HiredFilter { get; set; }
    }
}
