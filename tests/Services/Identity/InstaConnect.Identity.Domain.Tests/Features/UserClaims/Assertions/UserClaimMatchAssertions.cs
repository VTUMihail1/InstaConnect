using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(UserClaimId response)
	{
		public void ShouldSatisfy(UserClaim userClaim, AddUserClaimCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(userClaim, command));
		}
	}

	extension(UserClaimCollectionResponse response)
	{
		public void ShouldSatisfy(
			User user,
			ICollection<UserClaim> userClaims,
			GetAllUserClaimsQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(user, userClaims, query));
		}

		public void ShouldSatisfy(
			User user,
			ICollection<UserClaim> userClaims,
			GetAllUserClaimsQuery query,
			ISortEnumTermTransformer<UserClaim> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(user, userClaims, query, termTransformer));
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
