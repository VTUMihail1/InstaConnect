namespace InstaConnect.Chats.Application.Features.ChatMessages.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> ChatMessageIdMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(ChatMessageConfigurations.IdMinLength);
    }

    public static IRuleBuilderOptions<T, string> ChatMessageIdMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(ChatMessageConfigurations.IdMaxLength);
    }

    public static IRuleBuilderOptions<T, string> ChatMessageContentMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(ChatMessageConfigurations.ContentMinLength);
    }

    public static IRuleBuilderOptions<T, string> ChatMessageContentMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(ChatMessageConfigurations.ContentMaxLength);
    }

    public static IRuleBuilderOptions<T, int> ChatMessagePageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(ChatMessageConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> ChatMessagePageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(ChatMessageConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> ChatMessagePageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(ChatMessageConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> ChatMessagePageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(ChatMessageConfigurations.PageSizeMaxValue);
    }
}
