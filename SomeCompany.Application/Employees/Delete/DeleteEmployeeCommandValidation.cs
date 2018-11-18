using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Employees.Delete
{
    public class DeleteEmployeeCommandValidation : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidation()
        {
            RuleFor(c => c.Id)
                .ApplyIdRules();
        }
    }
}
