using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowForFollowerSortTermNotSupportedException : BadRequestException
{
    public FollowForFollowerSortTermNotSupportedException(FollowsForFollowerSortTerm sortTerm)
        : base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public FollowForFollowerSortTermNotSupportedException(FollowsForFollowerSortTerm sortTerm, Exception exception)
        : base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
