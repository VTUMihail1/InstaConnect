namespace InstaConnect.Follows.Presentation.Features.Follows.Utilities;

public static class FollowRoutes
{
    public const string Resource = "api/v{version:apiVersion}";

    public const string CurrentId = "followers/current/follows/{followingId}";

    public const string Follower = "followers/{followerId}/follows";

    public const string Following = "followings/{followingId}/follows";

    public const string Version1 = "1.0";
}

