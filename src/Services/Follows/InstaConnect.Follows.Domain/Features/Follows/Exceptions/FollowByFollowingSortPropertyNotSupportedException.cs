using InstaConnect.Common.Exceptions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
