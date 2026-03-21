using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

public static class RefreshTokenExceptionErrorMessages
{
    public static string GetNotFoundMessage(RefreshTokenId id)
    {
        const string Format = "RefreshToken(id: {0}, value: {1}) does not exist";
        var result = Format.FormatCurrentCulture(id.Id.Id, id.Value);

        return result;
    }

    public static string GetExpiredMessage(RefreshTokenId id)
    {
        const string Format = "RefreshToken(id: {0}, value: {1}) has expired";
        var result = Format.FormatCurrentCulture(id.Id.Id, id.Value);

        return result;
    }

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
    {
        const string Format = "RefreshTokenDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
    }
}
