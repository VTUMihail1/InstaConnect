using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenExceptionErrorMessages
{
	public static string GetNotFoundMessage(EmailConfirmationTokenId id)
	{
		const string Format = "EmailConfirmationToken(id: {0}, value: {1}) does not exist";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetExpiredMessage(EmailConfirmationTokenId id)
	{
		const string Format = "EmailConfirmationToken(id: {0}, value: {1}) has expired";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		const string Format = "EmailConfirmationTokenDescriptors({0}) is not supported";

		return Format.FormatCurrentCulture(descriptors
			.JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
	}
}
