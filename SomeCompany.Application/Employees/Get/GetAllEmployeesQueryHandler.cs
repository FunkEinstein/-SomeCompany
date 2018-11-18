using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SomeCompany.Application.Base;
using SomeCompany.Application.Employees.ResponseDto;
using SomeCompany.Database;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Employees.Get
{
    public class GetAllEmployeesQueryHandler : DbRequestHandlerBase<GetAllEmployeesQuery, AllEmployeesDto>
    {
        public GetAllEmployeesQueryHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<AllEmployeesDto> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var page = request.Page;
            var rowsOnPage = request.RowsOnPage;
            var skipRows = (page - 1) * rowsOnPage;

            var employees = DbContext.Employees.Where(e => e.DepartmentId == request.DepartmentId);
            var count = await employees.CountAsync(cancellationToken);
            var filteredEmployees = await employees
                .Where(e => Filter(e, request))
                .Skip(skipRows)
                .Take(rowsOnPage)
                .Include(e => e.Department)
                .Select(e => e.ToEmployeeInfoDto())
                .ToListAsync(cancellationToken);

            var allEmployeesInfo = new AllEmployeesDto(filteredEmployees, count);
            return allEmployeesInfo;
        }

        private static bool Filter(Employee employee, GetAllEmployeesQuery request)
        {
            var nameFilter = request.NameFilter;
            if (!string.IsNullOrEmpty(nameFilter) && !employee.Name.Contains(nameFilter))
                return false;

            var emailFilter = request.EmailFilter;
            if (!string.IsNullOrEmpty(emailFilter) && !employee.Email.Contains(emailFilter))
                return false;

            var salaryFilter = request.SalaryFilter;
            if (salaryFilter > 0 && employee.Salary != salaryFilter)
                return false;

            var hiredFilter = request.HiredFilter;
            if (hiredFilter != default(DateTime) && employee.Hired.Date != hiredFilter.Date)
                return false;
            
            return true;
        }
    }
}
