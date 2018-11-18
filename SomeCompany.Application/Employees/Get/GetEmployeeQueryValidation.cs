using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Employees.Get
{
    public class GetEmployeeQueryValidation : AbstractValidator<GetEmployeeQuery>
    {
        public GetEmployeeQueryValidation()
        {
            RuleFor(q => q.Id)
                .ApplyIdRules();
        }
    }
}
