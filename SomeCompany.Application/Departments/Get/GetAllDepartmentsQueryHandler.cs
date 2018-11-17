using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SomeCompany.Application.Base;
using SomeCompany.Application.Departments.Dto;
using SomeCompany.Database;

namespace SomeCompany.Application.Departments.Get
{
    public class GetAllDepartmentsQueryHandler : HandlerBase<GetAllDepartmentsQuery, AllDepartmentsDto>
    {
        public GetAllDepartmentsQueryHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<AllDepartmentsDto> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await DbContext.Departments
                .Select(d => new DepartmentDto(d))
                .ToListAsync(cancellationToken);

            var allDepartmentsDto = new AllDepartmentsDto(departments);
            return allDepartmentsDto;
        }
    }
}
