using System.Threading;
using System.Threading.Tasks;
using SomeCompany.Application.Base;
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
