using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

public static class RefreshTokenExceptionErrorMessages
{
	public static string GetNotFoundMessage(RefreshTokenId id)
	{
		const string Format = "RefreshToken(id: {0}, value: {1}) does not exist";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetExpiredMessage(RefreshTokenId id)
	{
		const string Format = "RefreshToken(id: {0}, value: {1}) has expired";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		const string Format = "RefreshTokenDescriptors({0}) is not supported";

		return Format.FormatCurrentCulture(descriptors
			.JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
	}
}
