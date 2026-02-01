namespace InstaConnect.Posts.Presentation.Features.PostComments.Utilities;

public static class PostCommentRoutes
{
    public const string Resource = "api/v{version:apiVersion}/posts/{id}/comments";

    public const string UserResource = "api/v{version:apiVersion}/users/{userId}/post-comments";

    public const string Id = "{commentId}";

    public const string Version1 = "1.0";
}
