using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.Database;

namespace SomeCompany.Application.Departments.Update
{
    public class UpdateDepartmentCommandHandler : IrresponsibleHandlerBase<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentDto = request.Department;
            var departmentId = departmentDto.Id;
            var department = await DbContext.Departments.FindAsync(departmentId);

            if (department == null)
                throw new DepartmentNotFoundException(departmentId);

            department.DepartmentName = departmentDto.DepartmentName;
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
