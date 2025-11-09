using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

public static class UserClaimExceptionErrorMessages
{
    public static string GetInclidePropertyNotSupportedMessage(ICollection<UserClaimIncludeProperty> includeProperties)
    {
        const string Format = "UserClaimIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
