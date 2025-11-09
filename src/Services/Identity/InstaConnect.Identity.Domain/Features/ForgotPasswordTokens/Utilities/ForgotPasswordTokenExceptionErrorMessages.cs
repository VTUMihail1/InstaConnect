using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string value)
    {
        const string Format = "ForgotPasswordToken(id: {0}, value: {1}) does not exist";
        var result = Format.FormatCurrentCulture(id, value);

        return result;
    }

    public static string GetExpiredMessage(string id, string value)
    {
        const string Format = "ForgotPasswordToken(id: {0}, value: {1}) has expired";
        var result = Format.FormatCurrentCulture(id, value);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<ForgotPasswordTokenIncludeProperty> includeProperties)
    {
        const string Format = "ForgotPasswordTokenIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
