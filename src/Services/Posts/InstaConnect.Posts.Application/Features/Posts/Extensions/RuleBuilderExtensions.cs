namespace InstaConnect.Posts.Application.Features.Posts.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> PostIdMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(PostConfigurations.IdMinLength);
    }

    public static IRuleBuilderOptions<T, string> PostIdMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(PostConfigurations.IdMaxLength);
    }

    public static IRuleBuilderOptions<T, string> PostTitleMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(PostConfigurations.TitleMinLength);
    }

    public static IRuleBuilderOptions<T, string> PostTitleMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(PostConfigurations.TitleMaxLength);
    }

    public static IRuleBuilderOptions<T, string> PostContentMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(PostConfigurations.ContentMinLength);
    }

    public static IRuleBuilderOptions<T, string> PostContentMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(PostConfigurations.ContentMaxLength);
    }

    public static IRuleBuilderOptions<T, int> PostPageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostPageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> PostPageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostPageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostConfigurations.PageSizeMaxValue);
    }
}
