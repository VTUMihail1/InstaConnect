using System.Linq.Expressions;

using FluentValidation;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Common.Application.Features.Validations.Extensions;

public static class RuleBuilderExtensions
{
    private const string PropertyNamePlaceholder = "{PropertyName}";

    extension<T, TProperty>(IRuleBuilder<T, TProperty> ruleBuilder)
    {
        public IRuleBuilderOptions<T, TProperty> NotEmptyWithMessage()
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(CommonErrorMessages.GetEmpty(PropertyNamePlaceholder));
        }

        public IRuleBuilderOptions<T, TProperty> EqualWithMessage(Expression<Func<T, TProperty>> equalPropertyExpression)
        {
            return ruleBuilder
                .Equal(equalPropertyExpression)
                .WithMessage(CommonErrorMessages.GetNotEqual(PropertyNamePlaceholder, equalPropertyExpression.GetProperty()));
        }
    }

    extension<T>(IRuleBuilder<T, string> ruleBuilder)
    {
        public IRuleBuilderOptions<T, string> MinLengthWithMessage(int minLength)
        {
            return ruleBuilder
                .MinimumLength(minLength)
                .WithMessage((_, typeProperty) => CommonErrorMessages.GetMinLength(PropertyNamePlaceholder, typeProperty.Length, minLength));
        }

        public IRuleBuilderOptions<T, string> MaxLengthWithMessage(int maxLength)
        {
            return ruleBuilder
                .MaximumLength(maxLength)
                .WithMessage((_, typeProperty) => CommonErrorMessages.GetMaxLength(PropertyNamePlaceholder, typeProperty.Length, maxLength));
        }

        public IRuleBuilderOptions<T, string> InvalidEmailWithMessage()
        {
            return ruleBuilder
                .EmailAddress()
                .WithMessage(CommonErrorMessages.GetInvalidEmail(PropertyNamePlaceholder));
        }
    }

    extension<T>(IRuleBuilder<T, int> ruleBuilder)
    {
        public IRuleBuilderOptions<T, int> MinValueWithMessage(int minValue)
        {
            return ruleBuilder
                .GreaterThanOrEqualTo(minValue)
                .WithMessage((_, typeProperty) => CommonErrorMessages.GetMinValue(PropertyNamePlaceholder, typeProperty, minValue));
        }

        public IRuleBuilderOptions<T, int> MaxValueWithMessage(int maxValue)
        {
            return ruleBuilder
                .LessThanOrEqualTo(maxValue)
                .WithMessage((_, typeProperty) => CommonErrorMessages.GetMaxValue(PropertyNamePlaceholder, typeProperty, maxValue));
        }
    }
}
