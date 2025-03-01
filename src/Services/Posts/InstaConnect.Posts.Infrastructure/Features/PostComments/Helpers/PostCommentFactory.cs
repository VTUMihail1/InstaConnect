namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers;

internal class PostCommentFactory : IPostCommentFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostCommentFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public PostComment Get(string postId, string userId, string content)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postComment = new PostComment(
            id,
            userId,
            postId,
            content,
            utcNow,
            utcNow);

        return postComment;
    }
}
