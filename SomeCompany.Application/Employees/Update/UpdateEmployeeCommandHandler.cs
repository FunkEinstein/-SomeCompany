using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.Database;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Employees.Update
{
    public class UpdateEmployeeCommandHandler : DbRequestHandlerBase<UpdateEmployeeCommand, Unit>
    {
        public UpdateEmployeeCommandHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var employee = await DbContext.Employees.FindAsync(id);
            if (employee == null)
                throw new EmployeeNotFoundException(id);

            UpdateEmployee(employee, request);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void UpdateEmployee(Employee employee, UpdateEmployeeCommand request)
        {
            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Salary = request.Salary;
            employee.Hired = request.Hired;
            employee.DepartmentId = request.DepartmentId;
        }
    }
}
