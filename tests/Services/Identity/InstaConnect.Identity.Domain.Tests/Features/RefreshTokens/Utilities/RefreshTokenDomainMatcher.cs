namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDomainMatcher
{
	extension(IssueRefreshTokenCommand command)
	{
		public UserInclude IsUserInclude(UserInclude include)
		{
			return Matcher.Is<UserInclude>(p => p.Matches(command, include));
		}

		public RefreshToken IsRefreshToken()
		{
			return Matcher.Is<RefreshToken>(p => p.Matches(command));
		}
	}

	extension(RotateRefreshTokenCommand command)
	{
		public UserInclude IsUserInclude(UserInclude include)
		{
			return Matcher.Is<UserInclude>(p => p.Matches(command, include));
		}

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
