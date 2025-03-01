namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeFactory : IPostCommentLikeFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostCommentLikeFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public PostCommentLike Get(string postCommentId, string userId)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postCommentLike = new PostCommentLike(
            id,
            postCommentId,
            userId,
            utcNow,
            utcNow);

        return postCommentLike;
    }
}
