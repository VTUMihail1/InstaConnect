using InstaConnect.Common.Exceptions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

public class PostLikeNotFoundException : NotFoundException
{
    public PostLikeNotFoundException(string id, string likeId)
        : base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, likeId))
    {
    }

    public PostLikeNotFoundException(string id, string likeId, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, likeId), exception)
    {
    }
}
