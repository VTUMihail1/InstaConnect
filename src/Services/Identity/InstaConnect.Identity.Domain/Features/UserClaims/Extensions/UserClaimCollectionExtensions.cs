namespace InstaConnect.Identity.Domain.Features.UserClaims.Extensions;

public static class UserClaimCollectionExtensions
{
	extension(ICollection<UserClaim> userClaims)
	{
		public ICollection<UserClaim> AddUser(User user)
		{
			foreach (var userClaim in userClaims)
			{
				userClaim.AddUser(user);
			}

			return userClaims;
		}
	}
}
