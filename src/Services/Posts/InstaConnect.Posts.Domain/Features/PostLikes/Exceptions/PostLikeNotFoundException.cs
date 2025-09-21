using InstaConnect.Common.Exceptions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

public class PostLikeNotFoundException : NotFoundException
{
    public PostLikeNotFoundException(string id, string userId)
        : base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, userId))
    {
    }

    public PostLikeNotFoundException(string id, string userId, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, userId), exception)
    {
    }
}
