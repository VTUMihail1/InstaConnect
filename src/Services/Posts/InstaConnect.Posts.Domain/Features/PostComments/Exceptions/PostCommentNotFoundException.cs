using InstaConnect.Common.Exceptions;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Exceptions;

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
