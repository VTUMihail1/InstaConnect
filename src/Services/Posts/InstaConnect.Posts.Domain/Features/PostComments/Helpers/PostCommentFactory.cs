namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

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

    public PostComment Create(string id, string userId, string content)
    {
        var commentId = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var postComment = new PostComment(
            id,
            commentId,
            content,
            userId,
            utcNow,
            utcNow);

        return postComment;
    }
}
