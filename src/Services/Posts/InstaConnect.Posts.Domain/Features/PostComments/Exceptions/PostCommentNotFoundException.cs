using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentNotFoundException : NotFoundException
{
    public PostCommentNotFoundException(PostCommentId id)
        : base(PostCommentExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }

    public PostCommentNotFoundException(PostCommentId id, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetNotFoundMessage(id), exception)
    {
    }
}
