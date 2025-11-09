namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeFactory : IPostCommentLikeFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostCommentLikeFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public PostCommentLike Create(string id, string commentId, string userId)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postCommentLike = new PostCommentLike(
            id,
            commentId,
            userId,
            utcNow,
            utcNow);

        return postCommentLike;
    }
}
