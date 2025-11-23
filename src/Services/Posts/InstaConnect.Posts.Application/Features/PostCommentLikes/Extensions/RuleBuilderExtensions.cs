namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, int> PostCommentLikePageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostCommentLikeConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostCommentLikePageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostCommentLikeConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> PostCommentLikePageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostCommentLikeConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostCommentLikePageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostCommentLikeConfigurations.PageSizeMaxValue);
    }
}
