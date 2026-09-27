namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDomainMatcher
{
	public static UserInclude IsUserInclude(IssueRefreshTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static UserInclude IsUserInclude(RotateRefreshTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static RefreshToken IsRefreshToken(IssueRefreshTokenCommand command)
	{
		return Matcher.Is<RefreshToken>(p => p.Matches(command));
	}

	public static RefreshToken IsRefreshToken(RotateRefreshTokenCommand command)
	{
		return Matcher.Is<RefreshToken>(p => p.Matches(command));
	}

	public static RefreshToken IsRefreshToken(DeleteRefreshTokenCommand command)
	{
		return Matcher.Is<RefreshToken>(p => p.Matches(command));
	}
}
