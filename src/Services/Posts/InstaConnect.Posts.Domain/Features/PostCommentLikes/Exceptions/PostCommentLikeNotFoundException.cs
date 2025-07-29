using InstaConnect.Common.Exceptions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeNotFoundException : NotFoundException
{
    public PostCommentLikeNotFoundException(
        string id,
        string commentId,
        string commentLikeId)
        : base(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
            id,
            commentId,
            commentLikeId))
    {
    }

    public PostCommentLikeNotFoundException(
        string id,
        string commentId,
        string commentLikeId, 
        Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
            id,
            commentId,
            commentLikeId), exception)
    {
    }
}
