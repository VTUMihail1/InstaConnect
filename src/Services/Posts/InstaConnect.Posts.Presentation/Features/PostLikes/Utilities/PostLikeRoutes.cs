namespace InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

public static class PostLikeRoutes
{
    public const string Resource = "api/v{version:apiVersion}/posts/{id}/likes";

    public const string Id = "{userId}";

    public const string Current = "current";

    public const string Version1 = "1.0";
}

