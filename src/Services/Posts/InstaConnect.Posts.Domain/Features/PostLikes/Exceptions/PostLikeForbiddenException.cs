using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.Common.Exceptions.Users;

public class PostLikeForbiddenException : ForbiddenException
{
    public PostLikeForbiddenException(string id, string postId, string userId)
        : base(PostLikeExceptionErrorMessages.GetForbiddenMessage(id, postId, userId))
    {
    }

    public PostLikeForbiddenException(string id, string postId, string userId, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetForbiddenMessage(id, postId, userId), exception)
    {
    }
}
