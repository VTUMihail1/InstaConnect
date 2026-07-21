using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(UserClaimId response)
	{
		public void ShouldSatisfy(AddUserClaimCommand command, UserClaim userClaim)
		{
			response.ShouldSatisfy(p => p.Matches(command, userClaim));
		}
	}

	extension(UserClaimCollectionResponse response)
	{
		public void ShouldSatisfy(
			GetAllUserClaimsQuery query,
			User user,
			ICollection<UserClaim> userClaims)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, userClaims));
		}

		public void ShouldSatisfy(
			GetAllUserClaimsQuery query,
			User user,
			ICollection<UserClaim> userClaims,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, userClaims, termTransformer));
		}
	}

	extension(UserClaim userClaim)
	{
		public void ShouldSatisfy(AddUserClaimCommand command)
		{
			userClaim.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
