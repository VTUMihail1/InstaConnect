using InstaConnect.Common.Exceptions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowNotFoundException : NotFoundException
{
    public FollowNotFoundException(string followerId, string followingId)
        : base(FollowExceptionErrorMessages.GetNotFoundMessage(followerId, followingId))
    {
    }

    public FollowNotFoundException(string followerId, string followingId, Exception exception)
        : base(FollowExceptionErrorMessages.GetNotFoundMessage(followerId, followingId), exception)
    {
    }
}
