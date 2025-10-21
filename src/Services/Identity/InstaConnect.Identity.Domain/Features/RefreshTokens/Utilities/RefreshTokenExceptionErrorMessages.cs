using InstaConnect.Common.Extensions;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

public static class RefreshTokenExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id, string value)
    {
        const string Format = "RefreshToken(id: {0}, value: {1}) does not exist";
        var result = Format.FormatCurrentCulture(id, value);

        return result;
    }

    public static string GetExpiredMessage(string id, string value)
    {
        const string Format = "RefreshToken(id: {0}, value: {1}) has expired";
        var result = Format.FormatCurrentCulture(id, value);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<RefreshTokenIncludeProperty> includeProperties)
    {
        const string Format = "RefreshTokenIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
