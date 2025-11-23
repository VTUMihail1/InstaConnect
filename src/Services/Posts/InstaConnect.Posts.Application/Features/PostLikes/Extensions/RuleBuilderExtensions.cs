namespace InstaConnect.Posts.Application.Features.PostLikes.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, int> PostLikePageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostLikeConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostLikePageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostLikeConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> PostLikePageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(PostLikeConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> PostLikePageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(PostLikeConfigurations.PageSizeMaxValue);
    }
}
