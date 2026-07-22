namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimReference
{
	extension(UserClaim? userClaim)
	{
		public UserClaim? SetUser()
		{
			userClaim?.User?.AddUserClaim(userClaim);

			return userClaim;
		}
	}
}
