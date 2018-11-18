using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Employees.Update
{
    public class UpdateEmployeeCommandValidation : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            RuleFor(c => c.Id)
                .ApplyIdRules();

            RuleFor(c => c.Name)
                .ApplyEmployeeNameRules();

            RuleFor(c => c.Email)
                .ApplyEmployeeEmailRules();

            RuleFor(c => c.Salary)
                .ApplyEmployeeSalaryRules();

            RuleFor(c => c.Hired)
                .ApplyEmployeeHiredRules();

            RuleFor(c => c.DepartmentId)
                .ApplyIdRules();

        }
    }
}
