using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Application.Base;
using SomeCompany.Application.Exceptions;
using SomeCompany.DatabaseProvider;

namespace SomeCompany.Application.Employees.Delete
{
    public class DeleteEmployeeCommandHandler : DbRequestHandlerBase<DeleteEmployeeCommand, Unit>
    {
        public DeleteEmployeeCommandHandler(CompanyDbContext dbContext) 
            : base(dbContext)
        { }

        public override async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var employee = await DbContext.Employees.FindAsync(id);
            if (employee == null)
                throw new EmployeeNotFoundException(id);

            DbContext.Employees.Remove(employee);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
