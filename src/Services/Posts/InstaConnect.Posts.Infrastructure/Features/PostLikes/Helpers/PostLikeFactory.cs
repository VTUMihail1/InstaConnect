namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers;

internal class PostLikeFactory : IPostLikeFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostLikeFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public PostLike Get(string postId, string userId)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postLike = new PostLike(
            id,
            postId,
            userId,
            utcNow,
            utcNow);

        return postLike;
    }
}
