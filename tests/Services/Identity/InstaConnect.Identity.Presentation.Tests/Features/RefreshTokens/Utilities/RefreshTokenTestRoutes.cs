namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenTestRoutes
{
    private static string GetDefaultName(string name)
    {
        const string Format = "api/v1/users/{0}/refresh-tokens";

        return Format.FormatCurrentCulture(name);
    }

    private static string GetDefaultCurrent()
    {
        const string Route = "api/v1/users/current/refresh-tokens";

        return Route;
    }

    private static string GetCurrent()
    {
        const string Format = "{0}/current";

        return Format.FormatCurrentCulture(GetDefaultCurrent());
    }

    public static string GetRoute(IssueRefreshTokenApiRequest request)
    {
        return GetDefaultName(request.Name);
    }

    public static string GetRoute(RotateRefreshTokenApiRequest request)
    {
        return GetCurrent();
    }

    public static string GetRoute(DeleteCurrentRefreshTokenApiRequest request)
    {
        return GetCurrent();
    }
}
