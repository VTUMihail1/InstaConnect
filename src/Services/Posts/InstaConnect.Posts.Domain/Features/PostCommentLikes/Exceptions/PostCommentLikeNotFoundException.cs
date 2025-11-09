using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeNotFoundException : NotFoundException
{
    public PostCommentLikeNotFoundException(
        string id,
        string commentId,
        string userId)
        : base(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
            id,
            commentId,
            userId))
    {
    }

    public PostCommentLikeNotFoundException(
        string id,
        string commentId,
        string userId,
        Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
            id,
            commentId,
            userId), exception)
    {
    }
}
