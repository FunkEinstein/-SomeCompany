using System.Threading;
using System.Threading.Tasks;
using SomeCompany.Application.Base;
using SomeCompany.Application.Employees.ResponseDto;
using SomeCompany.Application.Exceptions;
using SomeCompany.Database;

namespace SomeCompany.Application.Employees.Get
{
    public class GetEmployeeQueryHandler : DbRequestHandlerBase<GetEmployeeQuery, EmployeeInfoDto>
    {
        public GetEmployeeQueryHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<EmployeeInfoDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var employee = await DbContext.Employees.FindAsync(id);
            if (employee == null)
                throw new EmployeeNotFoundException(id);

            var employeeInfo = employee.ToEmployeeInfoDto();
            return employeeInfo;
        }
    }
}
