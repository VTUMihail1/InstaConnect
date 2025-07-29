using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.Common.Exceptions.Users;

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
