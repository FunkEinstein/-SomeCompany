using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Departments.Get
{
    public class GetAllDepartmentsQueryValidation : AbstractValidator<GetAllDepartmentsQuery>
    {
        public GetAllDepartmentsQueryValidation()
        {
            RuleFor(q => q.Page)
                .ApplyPageRules();

            RuleFor(q => q.RowsOnPage)
                .ApplyRowsOnPageRules();
        }
    }
}
