using InstaConnect.Common.Exceptions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

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
