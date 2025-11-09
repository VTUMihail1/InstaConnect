using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeAlreadyExistsException : NotFoundException
{
    public PostCommentLikeAlreadyExistsException(
        string id,
        string commentId,
        string userId)
        : base(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
            id,
            commentId,
            userId))
    {
    }

    public PostCommentLikeAlreadyExistsException(
        string id,
        string commentId,
        string userId,
        Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
            id,
            commentId,
            userId), exception)
    {
    }
}
