using InstaConnect.Common.Exceptions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Exceptions;

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
