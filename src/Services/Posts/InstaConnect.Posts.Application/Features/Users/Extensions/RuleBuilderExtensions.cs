namespace InstaConnect.Posts.Application.Features.Users.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, string> UserIdMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.IdMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserIdMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.IdMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserEmailMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.EmailMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserEmailMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.EmailMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserFirstNameMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.FirstNameMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserFirstNameMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.FirstNameMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserLastNameMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.LastNameMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserLastNameMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.LastNameMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserNameMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.NameMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserNameMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.NameMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserProfileImageMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.ProfileImageMaxLength);
    }
}
