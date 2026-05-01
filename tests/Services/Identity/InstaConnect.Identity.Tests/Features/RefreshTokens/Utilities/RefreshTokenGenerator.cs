namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenGenerator
{
	extension(RefreshToken baseRefreshToken)
	{
		public ICollection<RefreshToken> Generate(IEnumerable<User> users, int numberOfIterations = 3)
		{
			return [baseRefreshToken, .. users
			   .SelectMany(user =>
				   Enumerable.Range(default, numberOfIterations).Select(_ =>
				   {
					  var refreshToken = new RefreshToken(
						  new(user.Id, RefreshTokenDataFaker.GetValue()),
						  RefreshTokenDataFaker.GetExpiresAtUtc(),
						  RefreshTokenDataFaker.GetCreatedAtUtc());

					  user.AddRefreshToken(refreshToken);
					  refreshToken.AddUser(user);

					  return refreshToken;
				   }))];
		}
	}
}
