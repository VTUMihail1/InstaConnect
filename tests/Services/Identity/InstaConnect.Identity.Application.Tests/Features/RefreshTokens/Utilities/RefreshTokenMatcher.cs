namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMatcher
{
    public static IssueRefreshTokenCommand IsIssueRefreshTokenCommand(IssueRefreshTokenCommandRequest request)
    {
        return Matcher.Is<IssueRefreshTokenCommand>(p => p.Matches(request));
    }

    public static RotateRefreshTokenCommand IsRotateRefreshTokenCommand(RotateRefreshTokenCommandRequest request)
    {
        return Matcher.Is<RotateRefreshTokenCommand>(p => p.Matches(request));
    }

    public static DeleteRefreshTokenCommand IsDeleteRefreshTokenCommand(DeleteCurrentRefreshTokenCommandRequest request)
    {
        return Matcher.Is<DeleteRefreshTokenCommand>(p => p.Matches(request));
    }
}
