using FluentValidation;
using SomeCompany.Application.Extensions;

namespace SomeCompany.Application.Employees.Add
{
    public class AddEmployeeCommandValidation : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidation()
        {
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
