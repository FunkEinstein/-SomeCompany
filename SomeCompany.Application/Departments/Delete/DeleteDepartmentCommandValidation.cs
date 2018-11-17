using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Departments.Delete
{
    public class DeleteDepartmentCommandValidation : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidation()
        {
            RuleFor(c => c.Id)
                .ApplyDepartmentIdRules();
        }
    }
}
