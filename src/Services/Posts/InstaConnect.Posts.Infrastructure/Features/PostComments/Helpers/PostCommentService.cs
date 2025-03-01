using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers;
internal class PostCommentService : IPostCommentService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostCommentService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public void Update(PostComment postComment, string content)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        postComment.Update(content, utcNow);
    }
}
