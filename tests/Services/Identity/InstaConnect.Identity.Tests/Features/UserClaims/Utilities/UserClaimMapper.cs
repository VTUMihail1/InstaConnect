using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

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

		public UserClaim ToFull()
		{
			return new UserClaim(userClaim.Id,
					   userClaim.CreatedAtUtc)
				.AddUser(userClaim.User?.ToFull());
		}

		public UserClaim ToWithoutUser()
		{
			return new(userClaim.Id,
					   userClaim.CreatedAtUtc);
		}
	}
}
