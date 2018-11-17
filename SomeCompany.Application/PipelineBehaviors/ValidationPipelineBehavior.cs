using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.PipelineBehaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext(request);

            var errors = new List<ValidationFailure>();
            foreach (var validator in _validators)
            {
                var result = validator.Validate(validationContext);
                var validationFailures = result.Errors;
                if (!validationFailures.IsNullOrEmpty())
                    errors.AddRange(validationFailures);
            }

            if (!errors.IsNullOrEmpty())
                throw new ValidationException("Request is not valid", errors);

            return next();
        }
    }
}
