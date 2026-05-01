namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeRoutes
{
	public const string Resource = "api/v{version:apiVersion}/posts/{id}/comments/{commentId}/likes";

	public const string UserResource = "api/v{version:apiVersion}/users/{userId}/post-comment-likes";

	public const string Id = "{userId}";

	public const string Current = "current";

	public const string Version1 = "1.0";
}
