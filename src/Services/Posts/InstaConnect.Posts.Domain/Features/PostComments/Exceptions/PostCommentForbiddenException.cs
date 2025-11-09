using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentForbiddenException : ForbiddenException
{
    public PostCommentForbiddenException(string id, string commentId, string userId)
        : base(PostCommentExceptionErrorMessages.GetForbiddenMessage(id, commentId, userId))
    {
    }

    public PostCommentForbiddenException(string id, string commentId, string userId, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetForbiddenMessage(id, commentId, userId), exception)
    {
    }
}
