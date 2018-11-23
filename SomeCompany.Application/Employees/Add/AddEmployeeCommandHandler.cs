using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.DatabaseProvider;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Employees.Add
{
    public class AddEmployeeCommandHandler : DbRequestHandlerBase<AddEmployeeCommand, int>
    {
        public AddEmployeeCommandHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEmail = request.Email;
            var employeeWithSameEmail = await DbContext.Employees
                .FirstOrDefaultAsync(e => e.Email == employeeEmail, cancellationToken);
            if (employeeWithSameEmail != null)
                throw new EmailAlreadyExistException(employeeEmail);

            var departmentId = request.DepartmentId;
            var department = await DbContext.Departments.FindAsync(departmentId);
            if (department == null)
                throw new DepartmentNotFoundException(departmentId);

            var employee = CreateEmployee(request);

            DbContext.Employees.Add(employee);
            await DbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }

        private Employee CreateEmployee(AddEmployeeCommand request)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Salary = request.Salary,
                Hired = request.Hired,
                DepartmentId = request.DepartmentId
            };

            return employee;
        }
    }
}
