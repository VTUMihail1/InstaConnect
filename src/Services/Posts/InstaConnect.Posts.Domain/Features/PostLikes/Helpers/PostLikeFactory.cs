namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

internal class PostLikeFactory : IPostLikeFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostLikeFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public PostLike Create(string id, string userId)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postLike = new PostLike(
            id,
            userId,
            utcNow,
            utcNow);

        return postLike;
    }
}
