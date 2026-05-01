using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeDefaultValues
{
	public const PostCommentLikesSortTerm SortTerm = PostCommentLikesSortTerm.ByCreatedAt;

	public const PostCommentLikesForUserSortTerm SortTermForUser = PostCommentLikesForUserSortTerm.ByCreatedAt;

	public const int Page = 1;

	public const int PageSize = 20;
}
