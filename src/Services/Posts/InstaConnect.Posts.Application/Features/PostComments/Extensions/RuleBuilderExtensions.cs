namespace InstaConnect.Posts.Application.Features.PostComments.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> PostCommentIdMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(PostCommentConfigurations.IdMinLength);
    }

    public static IRuleBuilderOptions<T, string> PostCommentIdMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(PostCommentConfigurations.IdMaxLength);
    }

    public static IRuleBuilderOptions<T, string> PostCommentContentMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(PostCommentConfigurations.ContentMinLength);
    }

    public static IRuleBuilderOptions<T, string> PostCommentContentMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(PostCommentConfigurations.ContentMaxLength);
    }

    public static IRuleBuilderOptions<T, int> PostCommentPageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostCommentConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostCommentPageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostCommentConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> PostCommentPageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostCommentConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostCommentPageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostCommentConfigurations.PageSizeMaxValue);
    }
}
