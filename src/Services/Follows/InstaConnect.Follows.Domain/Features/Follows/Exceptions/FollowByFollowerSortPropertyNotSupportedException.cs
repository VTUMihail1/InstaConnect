using InstaConnect.Common.Exceptions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
