namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;

public abstract class PostCommentLikeRoutes
{
    public const string Resource = "api/v{version:apiVersion}/posts/{postId}/comments/{postCommentId}/likes";

    public const string Id = "{id}";

    public const string Version1 = "1.0";
}

