namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

public static class RefreshTokenRoutes
{
    public const string Version1 = "1.0";
    public const string Resource = "api/v{version:apiVersion}/users";
    public const string Issue = "{name}/refresh-tokens";
    public const string CurrentRotate = "current/refresh-tokens/current/rotate";
    public const string Current = "current/refresh-tokens/current";
}
