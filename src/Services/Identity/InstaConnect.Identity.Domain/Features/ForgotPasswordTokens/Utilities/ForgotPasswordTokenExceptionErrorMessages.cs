using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenExceptionErrorMessages
{
	public static string GetNotFoundMessage(ForgotPasswordTokenId id)
	{
		const string Format = "ForgotPasswordToken(id: {0}, value: {1}) does not exist";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetExpiredMessage(ForgotPasswordTokenId id)
	{
		const string Format = "ForgotPasswordToken(id: {0}, value: {1}) has expired";

		return Format.FormatCurrentCulture(id.Id.Id, id.Value);
	}

	public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		const string Format = "ForgotPasswordTokenDescriptors({0}) is not supported";

		return Format.FormatCurrentCulture(descriptors
			.JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
	}
}
