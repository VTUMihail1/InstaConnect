namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMatcher
{
	public static SetRefreshTokenCookieRequest IsRefreshTokenCookieRequest(RefreshToken refreshToken)
	{
		return Matcher.Is<SetRefreshTokenCookieRequest>(p => p.Matches(refreshToken));
	}

	public static IssueRefreshTokenCommandRequest IsIssueRefreshTokenCommandRequest(IssueRefreshTokenApiRequest request)
	{
		return Matcher.Is<IssueRefreshTokenCommandRequest>(p => p.Matches(request));
	}

	public static RotateRefreshTokenCommandRequest IsRotateRefreshTokenCommandRequest(RotateRefreshTokenApiRequest request)
	{
		return Matcher.Is<RotateRefreshTokenCommandRequest>(p => p.Matches(request));
	}

	public static DeleteCurrentRefreshTokenCommandRequest IsDeleteCurrentRefreshTokenCommandRequest(DeleteCurrentRefreshTokenApiRequest request)
	{
		return Matcher.Is<DeleteCurrentRefreshTokenCommandRequest>(p => p.Matches(request));
	}
}
