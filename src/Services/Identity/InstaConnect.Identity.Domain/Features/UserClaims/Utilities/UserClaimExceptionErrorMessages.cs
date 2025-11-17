using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

public static class UserClaimExceptionErrorMessages
{
    public static string GetInclidePropertyNotSupportedMessage(ICollection<UserClaimIncludeProperty> includeProperties)
    {
        const string Format = "UserClaimIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
