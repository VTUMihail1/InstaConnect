using InstaConnect.Common.Exceptions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

public class PostLikeNotFoundException : NotFoundException
{
    public PostLikeNotFoundException(string id, string postId)
        : base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, postId))
    {
    }

    public PostLikeNotFoundException(string id, string postId, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id, postId), exception)
    {
    }
}
