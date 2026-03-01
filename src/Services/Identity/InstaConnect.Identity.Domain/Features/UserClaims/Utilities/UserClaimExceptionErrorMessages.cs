using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

public static class UserClaimExceptionErrorMessages
{
    public static string GetInclideDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
    {
        const string Format = "UserClaimDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
    }
}
