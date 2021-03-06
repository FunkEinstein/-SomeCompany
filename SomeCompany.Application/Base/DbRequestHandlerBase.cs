﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SomeCompany.DatabaseProvider;

namespace SomeCompany.Application.Base
{
    public abstract class DbRequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly CompanyDbContext DbContext;

        protected DbRequestHandlerBase(CompanyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
