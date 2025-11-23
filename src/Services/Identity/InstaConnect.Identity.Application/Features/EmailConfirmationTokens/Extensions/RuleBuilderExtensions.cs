namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> EmailConfirmationTokenValueMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(EmailConfirmationTokenConfigurations.ValueMinLength);
    }

    public static IRuleBuilderOptions<T, string> EmailConfirmationTokenValueMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(EmailConfirmationTokenConfigurations.ValueMaxLength);
    }
}
