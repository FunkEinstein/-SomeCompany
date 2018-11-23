using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.DatabaseProvider;
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

            var employeeEmail = request.Email;
            var employeeWithSameEmail = await DbContext.Employees
                .FirstOrDefaultAsync(e => e.Email == employeeEmail, cancellationToken);
            if (employeeWithSameEmail != null && employeeWithSameEmail.Id != id)
                throw new EmailAlreadyExistException(employeeEmail);

            var departmentId = request.DepartmentId;
            var department = await DbContext.Departments.FindAsync(departmentId);
            if (department == null)
                throw new DepartmentNotFoundException(departmentId);

            UpdateEmployee(employee, request);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void UpdateEmployee(Employee employee, UpdateEmployeeCommand request)
        {
            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Salary = request.Salary;
            employee.Hired = request.Hired.ToUniversalTime();
            employee.DepartmentId = request.DepartmentId;
        }
    }
}
