using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Utilities;

public static class UserClaimExceptionErrorMessages
{
    public static string GetInclidePropertyNotSupportedMessage(ICollection<UserClaimIncludeProperty> includeProperties)
    {
        const string Format = "UserClaimIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
