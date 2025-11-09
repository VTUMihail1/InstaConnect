using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostForbiddenException : ForbiddenException
{
    public PostForbiddenException(string id, string userId)
        : base(PostExceptionErrorMessages.GetForbiddenMessage(id, userId))
    {
    }

    public PostForbiddenException(string id, string userId, Exception exception)
        : base(PostExceptionErrorMessages.GetForbiddenMessage(id, userId), exception)
    {
    }
}
