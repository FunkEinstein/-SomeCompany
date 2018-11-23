using System.Threading;
using System.Threading.Tasks;
using SomeCompany.Application.Base;
using SomeCompany.Application.Departments.ResponseDto;
using SomeCompany.Application.Exceptions;
using SomeCompany.DatabaseProvider;

namespace SomeCompany.Application.Departments.Get
{
    public class GetDepartmentQueryHandler : DbRequestHandlerBase<GetDepartmentQuery, DepartmentInfoDto>
    {
        public GetDepartmentQueryHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<DepartmentInfoDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departmentId = request.Id;
            var department = await DbContext.Departments.FindAsync(departmentId);
            if (department == null)
                throw new DepartmentNotFoundException(departmentId);

            var departmentInfo = department.ToDepartmentInfoDto();
            return departmentInfo;
        }
    }
}
