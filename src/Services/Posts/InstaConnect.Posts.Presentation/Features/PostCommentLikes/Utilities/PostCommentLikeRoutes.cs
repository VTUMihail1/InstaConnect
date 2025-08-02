namespace InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeRoutes
{
    public const string Resource = "api/v{version:apiVersion}/posts/{id}/comments/{commentId}/likes";

    public const string Id = "{commentLikeId}";

    public const string Version1 = "1.0";
}

