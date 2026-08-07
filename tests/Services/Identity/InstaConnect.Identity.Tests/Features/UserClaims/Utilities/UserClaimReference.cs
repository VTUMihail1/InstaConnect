namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimReference
{
	extension(ICollection<UserClaim> userClaims)
	{
		public ICollection<UserClaim> SetUser()
		{
			foreach (var userClaim in userClaims)
			{
				userClaim.SetUser();
			}

			return userClaims;
		}
	}

	extension(UserClaim? userClaim)
	{
		public UserClaim? SetUser()
		{
			userClaim?.User?.AddUserClaim(userClaim);

			return userClaim;
		}
	}
}
