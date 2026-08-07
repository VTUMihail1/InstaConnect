using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		public UserClaimId ToId(
)
		{
			return userClaim.Id;
		}
	}
}
