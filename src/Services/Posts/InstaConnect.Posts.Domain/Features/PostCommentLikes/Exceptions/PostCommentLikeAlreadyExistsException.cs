using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeAlreadyExistsException : NotFoundException
{
    public PostCommentLikeAlreadyExistsException(PostCommentLikeId id)
        : base(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(id))
    {
    }

    public PostCommentLikeAlreadyExistsException(PostCommentLikeId id, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
    {
    }
}
