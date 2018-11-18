using System;
using FluentValidation;

namespace SomeCompany.Application.Extensions
{
    public static class EmployeeValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ApplyEmployeeNameRules<T>(this IRuleBuilder<T, string> builderOptions)
        {
            return builderOptions
                .NotNull()
                .NotEmpty();
        }

        public static IRuleBuilderOptions<T, string> ApplyEmployeeEmailRules<T>(this IRuleBuilder<T, string> builderOptions)
        {
            return builderOptions
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }

        public static IRuleBuilderOptions<T, int> ApplyEmployeeSalaryRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0).WithMessage("Salary must be greater than zero");
        }

        public static IRuleBuilderOptions<T, DateTime> ApplyEmployeeHiredRules<T>(this IRuleBuilder<T, DateTime> builderOptions)
        {
            return builderOptions
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Hired date can't be in feature");
        }
    }
}
