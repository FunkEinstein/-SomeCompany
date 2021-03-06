﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.DatabaseProvider;

namespace SomeCompany.Application.Departments.Delete
{
    public class DeleteDepartmentCommandHandler : IrresponsibleHandlerBase<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentId = request.Id;
            var department = await DbContext.Departments.FindAsync(departmentId);
            if (department == null)
                throw new DepartmentNotFoundException(departmentId);

            // remove department's employees
            foreach (var employee in DbContext.Employees.Where(e => e.DepartmentId == departmentId))
                DbContext.Employees.Remove(employee);

            DbContext.Departments.Remove(department);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
