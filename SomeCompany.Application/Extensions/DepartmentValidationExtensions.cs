using FluentValidation;

namespace SomeCompany.Application.Extensions
{
    public static class DepartmentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ApplyDepartmentNameRules<T>(this IRuleBuilder<T, string> builderOptions)
        {
            return builderOptions
                .NotNull()
                .NotEmpty();
        }
    }
}
