using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeAlreadyExistsException : NotFoundException
{
    public PostLikeAlreadyExistsException(string id, string userId)
        : base(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id, userId))
    {
    }

    public PostLikeAlreadyExistsException(string id, string userId, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id, userId), exception)
    {
    }
}
