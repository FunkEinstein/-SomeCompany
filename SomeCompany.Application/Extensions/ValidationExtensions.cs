using FluentValidation;

namespace SomeCompany.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, int> ApplyDepartmentIdRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0);
        }

        public static IRuleBuilderOptions<T, string> ApplyDepartmentNameRules<T>(this IRuleBuilder<T, string> builderOptions)
        {
            return builderOptions
                .NotNull()
                .NotEmpty();
        }

        public static IRuleBuilderOptions<T, int> ApplyPageRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0);
        }

        public static IRuleBuilderOptions<T, int> ApplyRowsOnPageRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0);
        }
    }
}
