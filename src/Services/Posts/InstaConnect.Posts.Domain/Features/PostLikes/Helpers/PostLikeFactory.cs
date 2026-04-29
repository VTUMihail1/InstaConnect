namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

internal class PostLikeFactory : IPostLikeFactory
{
	private readonly IDateTimeProvider _dateTimeProvider;

	public PostLikeFactory(IDateTimeProvider dateTimeProvider)
	{
		_dateTimeProvider = dateTimeProvider;
	}

	public PostLike Create(PostId id, UserId userId)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var postLike = new PostLike(
			new(id, userId),
			utcNow);

		return postLike;
	}
}
