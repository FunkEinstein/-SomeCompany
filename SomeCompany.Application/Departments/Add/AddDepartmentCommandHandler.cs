using System.Threading;
using System.Threading.Tasks;
using SomeCompany.Application.Base;
using SomeCompany.Application.Departments.Dto;
using SomeCompany.Database;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Departments.Add
{
    public class AddDepartmentCommandHandler : HandlerBase<AddDepartmentCommand, int>
    {
        public AddDepartmentCommandHandler(CompanyDbContext dbContext)
            : base(dbContext)
        { }

        public override async Task<int> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentDto = request.Department;
            var department = CreateDepartment(departmentDto);

            DbContext.Departments.Add(department);
            await DbContext.SaveChangesAsync(cancellationToken);

            return department.Id;
        }

        private static Department CreateDepartment(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                DepartmentName = departmentDto.DepartmentName
            };

            return department;
        }
    }
}
