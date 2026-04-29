using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

public static class UserClaimExceptionErrorMessages
{
	public static string GetNotFoundMessage(UserClaimId id)
	{
		const string Format = "UserClaim(id: {0}, claim: {1}) does not exist";
		var result = Format.FormatCurrentCulture(id.Id.Id, id.Claim);

		return result;
	}

	public static string GetAlreadyExistsMessage(UserClaimId id)
	{
		const string Format = "UserClaim(id: {0}, claim: {1}) already exists";

		return Format.FormatCurrentCulture(id.Id.Id, id.Claim);
	}

	public static string GetSortTermNotSupportedMessage(UserClaimsSortTerm sortTerm)
	{
		const string Format = "UserClaimSortTerm(type: {0}) is not supported";

		return Format.FormatCurrentCulture(sortTerm);
	}

	public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
	{
		const string Format = "UserClaimDescriptors({0}) is not supported";

		return Format.FormatCurrentCulture(descriptors
			.JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
	}
}
