namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenPresentationMatcher
{
	public static SetRefreshTokenCookieApiRequest IsRefreshTokenCookieRequest(IssueRefreshTokenApiRequest request, RefreshToken refreshToken)
	{
		return Matcher.Is<SetRefreshTokenCookieApiRequest>(p => p.Matches(request, refreshToken));
	}

	public static SetRefreshTokenCookieApiRequest IsRefreshTokenCookieRequest(RotateRefreshTokenApiRequest request, RefreshToken refreshToken)
	{
		return Matcher.Is<SetRefreshTokenCookieApiRequest>(p => p.Matches(request, refreshToken));
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
