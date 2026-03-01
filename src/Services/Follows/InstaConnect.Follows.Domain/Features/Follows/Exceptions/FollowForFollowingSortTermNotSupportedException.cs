using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowForFollowingSortTermNotSupportedException : BadRequestException
{
    public FollowForFollowingSortTermNotSupportedException(FollowsForFollowingSortTerm sortTerm)
        : base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public FollowForFollowingSortTermNotSupportedException(FollowsForFollowingSortTerm sortTerm, Exception exception)
        : base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
