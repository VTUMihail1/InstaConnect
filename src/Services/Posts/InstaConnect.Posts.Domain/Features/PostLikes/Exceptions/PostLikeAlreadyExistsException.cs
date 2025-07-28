using InstaConnect.Common.Exceptions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

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
