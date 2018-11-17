using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SomeCompany.Application.Base;
using SomeCompany.Application.Departments.ResponseDto;
using SomeCompany.Database;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Departments.Get
{
    public class GetAllDepartmentsQueryHandler : HandlerBase<GetAllDepartmentsQuery, AllDepartmentsDto>
    {
        public GetAllDepartmentsQueryHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<AllDepartmentsDto> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var filter = request.NameFilter;
            var page = request.Page;
            var rowsOnPage = request.RowsOnPage;
            var skipRows = (page - 1) * rowsOnPage;

            var departments = await DbContext.Departments
                .Where(d => Filter(d, filter))
                .Skip(skipRows)
                .Take(rowsOnPage)
                .Select(d => d.ToDepartmentDto())
                .ToListAsync(cancellationToken);

            var allDepartmentsDto = new AllDepartmentsDto(departments);
            return allDepartmentsDto;
        }

        private static bool Filter(Department department, string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return true;

            return department.DepartmentName.Contains(filter);
        }
    }
}
