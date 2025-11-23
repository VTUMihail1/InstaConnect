namespace InstaConnect.Follows.Application.Features.Follows.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, int> FollowPageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(FollowConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> FollowPageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(FollowConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> FollowPageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(FollowConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> FollowPageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(FollowConfigurations.PageSizeMaxValue);
    }
}
