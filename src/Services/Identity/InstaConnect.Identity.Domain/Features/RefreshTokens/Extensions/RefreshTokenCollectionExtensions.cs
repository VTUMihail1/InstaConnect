namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Extensions;

public static class RefreshTokenCollectionExtensions
{
	extension(ICollection<RefreshToken> refreshTokens)
	{
		public ICollection<RefreshToken> AddUser(User user)
		{
			foreach (var refreshToken in refreshTokens)
			{
				refreshToken.AddUser(user);
			}

			return refreshTokens;
		}
	}
}
