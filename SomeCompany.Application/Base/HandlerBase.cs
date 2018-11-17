using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.Database;

namespace SomeCompany.Application.Base
{
    public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly CompanyDbContext DbContext;

        protected HandlerBase(CompanyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
