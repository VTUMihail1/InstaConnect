namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMatcher
{
	public static UserInclude IsUserInclude(IssueRefreshTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static UserInclude IsUserInclude(RotateRefreshTokenCommand command, UserInclude include)
	{
		return Matcher.Is<UserInclude>(p => p.Matches(command, include));
	}

	public static RefreshToken IsRefreshToken(IssueRefreshTokenCommand command, RefreshToken refreshToken)
	{
		return Matcher.Is<RefreshToken>(p => p.Matches(refreshToken));
	}

	public static RefreshToken IsRefreshToken(RotateRefreshTokenCommand command, RefreshToken refreshToken)
	{
		return Matcher.Is<RefreshToken>(p => p.Matches(refreshToken));
	}

	public static RefreshToken IsRefreshToken(DeleteRefreshTokenCommand command, RefreshToken refreshToken)
	{
		return Matcher.Is<RefreshToken>(p => p.Matches(refreshToken));
	}
}
