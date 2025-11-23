namespace InstaConnect.Chats.Application.Features.Users.Extensions;

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

    public static IRuleBuilderOptions<T, string> UserPasswordMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.PasswordMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserPasswordMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.PasswordMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserPasswordHashMinLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinLengthWithMessage(UserConfigurations.PasswordHashMinLength);
    }

    public static IRuleBuilderOptions<T, string> UserPasswordHashMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.PasswordHashMaxLength);
    }

    public static IRuleBuilderOptions<T, string> UserProfileImageMaxLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MaxLengthWithMessage(UserConfigurations.ProfileImageMaxLength);
    }

    public static IRuleBuilderOptions<T, int> UserPageMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(UserConfigurations.PageMinValue);
    }

    public static IRuleBuilderOptions<T, int> UserPageMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(UserConfigurations.PageMaxValue);
    }

    public static IRuleBuilderOptions<T, int> UserPageSizeMinValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MinValueWithMessage(UserConfigurations.PageSizeMinValue);
    }

    public static IRuleBuilderOptions<T, int> UserPageSizeMaxValueWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.MaxValueWithMessage(UserConfigurations.PageSizeMaxValue);
    }
}
