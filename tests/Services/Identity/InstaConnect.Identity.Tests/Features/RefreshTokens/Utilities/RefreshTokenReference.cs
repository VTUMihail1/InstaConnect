namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenReference
{
	extension(RefreshToken? refreshToken)
	{
		public RefreshToken? SetUser()
		{
			refreshToken?.User?.AddRefreshToken(refreshToken);

			return refreshToken;
		}
	}
}
