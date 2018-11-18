using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Departments.Update
{
    public class UpdateDepartmentCommandValidation : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidation()
        {
            RuleFor(c => c.Id)
                .ApplyIdRules();

            RuleFor(c => c.DepartmentName)
                .ApplyDepartmentNameRules();
        }
    }
}
