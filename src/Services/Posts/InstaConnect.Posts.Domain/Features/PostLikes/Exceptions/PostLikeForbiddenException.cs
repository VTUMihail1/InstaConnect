using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.Common.Exceptions.Users;

public class PostLikeForbiddenException : ForbiddenException
{
    public PostLikeForbiddenException(string id, string likeId, string userId)
        : base(PostLikeExceptionErrorMessages.GetForbiddenMessage(id, likeId, userId))
    {
    }

    public PostLikeForbiddenException(string id, string likeId, string userId, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetForbiddenMessage(id, likeId, userId), exception)
    {
    }
}
