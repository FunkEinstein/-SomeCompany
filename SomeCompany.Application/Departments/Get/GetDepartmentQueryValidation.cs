using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Departments.Get
{
    public class GetDepartmentQueryValidation : AbstractValidator<GetDepartmentQuery>
    {
        public GetDepartmentQueryValidation()
        {
            RuleFor(c => c.Id)
                .ApplyDepartmentIdRules();
        }
    }
}
