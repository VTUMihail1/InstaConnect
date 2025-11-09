using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentNotFoundException : NotFoundException
{
    public PostCommentNotFoundException(string id, string commentId)
        : base(PostCommentExceptionErrorMessages.GetNotFoundMessage(id, commentId))
    {
    }

    public PostCommentNotFoundException(string id, string commentId, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetNotFoundMessage(id, commentId), exception)
    {
    }
}
