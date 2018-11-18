using FluentValidation;

namespace SomeCompany.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, int> ApplyIdRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero");
        }

        public static IRuleBuilderOptions<T, int> ApplyPageRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero");
        }

        public static IRuleBuilderOptions<T, int> ApplyRowsOnPageRules<T>(this IRuleBuilder<T, int> builderOptions)
        {
            return builderOptions
                .GreaterThan(0)
                .WithMessage("Rows on page must be greater than zero");
        }
    }
}
