using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Utilities;

public static class PostCommentDefaultValues
{
	public const PostCommentsSortTerm SortTerm = PostCommentsSortTerm.ByCreatedAt;

	public const PostCommentsForUserSortTerm SortTermForUser = PostCommentsForUserSortTerm.ByCreatedAt;

	public const int Page = 1;

	public const int PageSize = 20;
}
