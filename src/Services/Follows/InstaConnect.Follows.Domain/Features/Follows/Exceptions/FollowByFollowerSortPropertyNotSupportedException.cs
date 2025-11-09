using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowByFollowerSortPropertyNotSupportedException : BadRequestException
{
    public FollowByFollowerSortPropertyNotSupportedException(FollowByFollowerSortProperty sortProperty)
        : base(FollowExceptionErrorMessages.GetByFollowerSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public FollowByFollowerSortPropertyNotSupportedException(FollowByFollowerSortProperty sortProperty, Exception exception)
        : base(FollowExceptionErrorMessages.GetByFollowerSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
