namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> ForgotPasswordTokenValueMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(ForgotPasswordTokenConfigurations.ValueMinLength);
    }

    public static IRuleBuilderOptions<T, string> ForgotPasswordTokenValueMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(ForgotPasswordTokenConfigurations.ValueMaxLength);
    }
}
