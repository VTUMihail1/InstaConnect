namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenReference
{
	extension(ICollection<RefreshToken> refreshTokens)
	{
		public ICollection<RefreshToken> SetUser()
		{
			foreach (var refreshToken in refreshTokens)
			{
				refreshToken.SetUser();
			}

			return refreshTokens;
		}
	}

	extension(RefreshToken? refreshToken)
	{
		public RefreshToken? SetUser()
		{
			refreshToken?.User?.AddRefreshToken(refreshToken);

			return refreshToken;
		}
	}
}
