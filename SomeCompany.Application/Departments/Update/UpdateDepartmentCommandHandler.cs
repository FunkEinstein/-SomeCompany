using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.Database;
using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Departments.Update
{
    public class UpdateDepartmentCommandHandler : IrresponsibleHandlerBase<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentId = request.Id;
            var department = await DbContext.Departments.FindAsync(departmentId);

            if (department == null)
                throw new DepartmentNotFoundException(departmentId);

            UpdateDepartment(department, request);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private static void UpdateDepartment(Department department, UpdateDepartmentCommand request)
        {
            department.DepartmentName = request.DepartmentName;
        }
    }
}
