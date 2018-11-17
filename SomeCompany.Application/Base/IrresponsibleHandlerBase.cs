using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Database;

namespace SomeCompany.Application.Base
{
    public abstract class IrresponsibleHandlerBase<TRequest> : HandlerBase<TRequest, Unit> 
        where TRequest : IRequest
    {
        protected IrresponsibleHandlerBase(CompanyDbContext dbContext)
            : base(dbContext)
        { }

        public abstract override Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
