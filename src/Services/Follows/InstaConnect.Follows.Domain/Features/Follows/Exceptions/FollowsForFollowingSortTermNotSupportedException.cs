using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowsForFollowingSortTermNotSupportedException : BadRequestException
{
    public FollowsForFollowingSortTermNotSupportedException(FollowsForFollowingSortTerm sortTerm)
        : base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public FollowsForFollowingSortTermNotSupportedException(FollowsForFollowingSortTerm sortTerm, Exception exception)
        : base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
