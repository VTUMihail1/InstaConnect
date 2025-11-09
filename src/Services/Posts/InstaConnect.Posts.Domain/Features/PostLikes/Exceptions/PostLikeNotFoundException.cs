using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

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
