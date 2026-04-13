namespace InstaConnect.Follows.Presentation.Features.Follows.Utilities;

public static class FollowRoutes
{
    public const string Resource = "api/v{version:apiVersion}/followers";

    public const string FollowingResource = "api/v{version:apiVersion}/followings/{followingId}/follows";

    public const string Id = "{followerId}/follows/{followingId}";

    public const string Current = "current/follows";

    public const string CurrentId = "current/follows/{followingId}";

    public const string Version1 = "1.0";
}

