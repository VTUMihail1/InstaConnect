namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDomainMatcher
{
	extension(IssueRefreshTokenCommand command)
	{
		public RefreshToken IsRefreshToken()
		{
			return Matcher.Is<RefreshToken>(p => p.Matches(command));
		}
	}

	extension(RotateRefreshTokenCommand command)
	{
		public RefreshToken IsRefreshToken()
		{
			return Matcher.Is<RefreshToken>(p => p.Matches(command));
		}
	}

	extension(DeleteRefreshTokenCommand command)
	{
		public RefreshToken IsRefreshToken()
		{
			return Matcher.Is<RefreshToken>(p => p.Matches(command));
		}
	}
}
