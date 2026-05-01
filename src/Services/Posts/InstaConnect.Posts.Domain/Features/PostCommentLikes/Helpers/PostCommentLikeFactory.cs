namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeFactory : IPostCommentLikeFactory
{
	private readonly IDateTimeProvider _dateTimeProvider;

	public PostCommentLikeFactory(IDateTimeProvider dateTimeProvider)
	{
		_dateTimeProvider = dateTimeProvider;
	}

	public PostCommentLike Create(PostCommentId commentId, UserId userId)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var postCommentLike = new PostCommentLike(
			new(commentId, userId),
			utcNow);

		return postCommentLike;
	}
}
