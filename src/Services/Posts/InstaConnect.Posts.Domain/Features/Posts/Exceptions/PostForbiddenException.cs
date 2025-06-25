using InstaConnect.Posts.Domain.Features.Posts.Utilities;

namespace InstaConnect.Common.Exceptions.Users;

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
