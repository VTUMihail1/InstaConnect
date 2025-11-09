using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowAlreadyExistsException : NotFoundException
{
    public FollowAlreadyExistsException(string followerId, string followingId)
        : base(FollowExceptionErrorMessages.GetAlreadyExistsMessage(followerId, followingId))
    {
    }

    public FollowAlreadyExistsException(string followerId, string followingId, Exception exception)
        : base(FollowExceptionErrorMessages.GetAlreadyExistsMessage(followerId, followingId), exception)
    {
    }
}
