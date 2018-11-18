using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.Database;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Departments.Add
{
    public class AddDepartmentCommandHandler : DbRequestHandlerBase<AddDepartmentCommand, int>
    {
        public AddDepartmentCommandHandler(CompanyDbContext dbContext)
            : base(dbContext)
        { }

        public override async Task<int> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentName = request.DepartmentName;
            var departmentWithSameName = await DbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentName == departmentName, cancellationToken);
            if (departmentWithSameName != null)
                throw new DepartmentNameAlreadyExistException(departmentName);

            var department = CreateDepartment(request);

            DbContext.Departments.Add(department);
            await DbContext.SaveChangesAsync(cancellationToken);

            return department.Id;
        }

        private static Department CreateDepartment(AddDepartmentCommand request)
        {
            var department = new Department
            {
                DepartmentName = request.DepartmentName
            };

            return department;
        }
    }
}
