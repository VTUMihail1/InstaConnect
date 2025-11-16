using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeAlreadyExistsException : NotFoundException
{
    public PostLikeAlreadyExistsException(PostLikeId id)
        : base(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id))
    {
    }

    public PostLikeAlreadyExistsException(PostLikeId id, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
    {
    }
}
