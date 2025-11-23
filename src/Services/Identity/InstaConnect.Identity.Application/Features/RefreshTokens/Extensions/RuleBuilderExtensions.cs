namespace InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> RefreshTokenValueMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(RefreshTokenConfigurations.ValueMinLength);
    }

    public static IRuleBuilderOptions<T, string> RefreshTokenValueMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(RefreshTokenConfigurations.ValueMaxLength);
    }
}
