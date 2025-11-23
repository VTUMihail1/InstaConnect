namespace InstaConnect.Chats.Application.Features.Chats.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, int> ChatPageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(ChatConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> ChatPageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(ChatConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> ChatPageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(ChatConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> ChatPageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(ChatConfigurations.PageSizeMaxValue);
    }
}
