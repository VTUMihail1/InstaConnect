using InstaConnect.Common.Extensions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string value)
    {
        const string Format = "EmailConfirmationToken(id: {0}, value: {1}) does not exist";
        var result = Format.FormatCurrentCulture(id, value);

        return result;
    }

    public static string GetExpiredMessage(string id, string value)
    {
        const string Format = "EmailConfirmationToken(id: {0}, value: {1}) has expired";
        var result = Format.FormatCurrentCulture(id, value);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties)
    {
        const string Format = "EmailConfirmationTokenIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
