using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Employees.Get
{
    public class GetAllEmployeesQueryValidation : AbstractValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidation()
        {
            RuleFor(q => q.Page)
                .ApplyPageRules();

            RuleFor(q => q.RowsOnPage)
                .ApplyRowsOnPageRules();

            RuleFor(q => q.DepartmentId)
                .ApplyIdRules();
        }
    }
}
