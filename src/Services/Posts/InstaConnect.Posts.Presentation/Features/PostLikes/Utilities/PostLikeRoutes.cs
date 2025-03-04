namespace InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;

public abstract class PostLikeRoutes
{
    public const string Resource = "api/v{version:apiVersion}/posts/{postId}/likes";

    public const string Id = "{id}";

    public const string Version1 = "1.0";
}

