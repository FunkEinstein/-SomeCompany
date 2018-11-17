using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Departments.Add
{
    public class AddDepartmentCommandValidation : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidation()
        {
            RuleFor(c => c.DepartmentName)
                .ApplyDepartmentNameRules();
        }
    }
}
