using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowByFollowingSortPropertyNotSupportedException : BadRequestException
{
    public FollowByFollowingSortPropertyNotSupportedException(FollowByFollowingSortProperty sortProperty)
        : base(FollowExceptionErrorMessages.GetByFollowingSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public FollowByFollowingSortPropertyNotSupportedException(FollowByFollowingSortProperty sortProperty, Exception exception)
        : base(FollowExceptionErrorMessages.GetByFollowingSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
