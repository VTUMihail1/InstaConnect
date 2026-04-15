using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeNotFoundException : NotFoundException
{
    public PostCommentLikeNotFoundException(PostCommentLikeId id)
        : base(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }

    public PostCommentLikeNotFoundException(PostCommentLikeId id, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(id), exception)
    {
    }
}
