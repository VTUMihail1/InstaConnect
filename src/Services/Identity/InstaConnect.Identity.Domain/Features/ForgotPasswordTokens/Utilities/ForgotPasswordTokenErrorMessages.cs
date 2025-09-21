using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Posts.Common.Features.RefreshTokens.Utilities;

public static class ForgotPasswordTokenErrorMessages
{
    public static string GetValueEmpty()
    {
        const string Message = "Value must not be empty.";

        return Message;
    }

    public static string GetValueTooShort(int length)
    {
        const string Format = "Value length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariantCulture(length, RefreshTokenConfigurations.ValueMinLength);
    }

    public static string GetValueTooLong(int length)
    {
        const string Format = "Value length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, RefreshTokenConfigurations.ValueMaxLength);
    }
}
