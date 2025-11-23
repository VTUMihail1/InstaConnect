using System.Linq.Expressions;

using FluentValidation;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Common.Application.Extensions;

public static class RuleBuilderExtensions
{
    private const string PropertyNamePlaceholder = "{PropertyName}";

    public static IRuleBuilderOptions<T, TProperty> NotEmptyWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage(CommonErrorMessages.GetEmpty(PropertyNamePlaceholder));
    }

    public static IRuleBuilderOptions<T, TProperty> EqualWithMessage<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        Expression<Func<T, TProperty>> equalPropertyExpression)
    {
        return ruleBuilder
            .Equal(equalPropertyExpression)
            .WithMessage(CommonErrorMessages.GetEqual(PropertyNamePlaceholder, equalPropertyExpression.GetFullPropertyPath()));
    }

    public static IRuleBuilderOptions<T, string> MinLengthWithMessage<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        int minLength)
    {
        return ruleBuilder
            .MinimumLength(minLength)
            .WithMessage((_, typeProperty) => CommonErrorMessages.GetMinLength(PropertyNamePlaceholder, typeProperty.Length, minLength));
    }

    public static IRuleBuilderOptions<T, string> MaxLengthWithMessage<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        int maxLength)
    {
        return ruleBuilder
            .MaximumLength(maxLength)
            .WithMessage((_, typeProperty) => CommonErrorMessages.GetMaxLength(PropertyNamePlaceholder, typeProperty.Length, maxLength));
    }

    public static IRuleBuilderOptions<T, int> MinValueWithMessage<T>(
        this IRuleBuilder<T, int> ruleBuilder,
        int minValue)
    {
        return ruleBuilder
            .GreaterThanOrEqualTo(minValue)
            .WithMessage((_, typeProperty) => CommonErrorMessages.GetMinValue(PropertyNamePlaceholder, typeProperty, minValue));
    }

    public static IRuleBuilderOptions<T, int> MaxValueWithMessage<T>(
        this IRuleBuilder<T, int> ruleBuilder,
        int maxValue)
    {
        return ruleBuilder
            .LessThanOrEqualTo(maxValue)
            .WithMessage((_, typeProperty) => CommonErrorMessages.GetMaxValue(PropertyNamePlaceholder, typeProperty, maxValue));
    }
}
