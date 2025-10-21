using InstaConnect.Common.Exceptions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowIncludePropertiesNotSupportedException : BadRequestException
{
    public FollowIncludePropertiesNotSupportedException(ICollection<FollowIncludeProperty> includeProperties)
        : base(FollowExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public FollowIncludePropertiesNotSupportedException(ICollection<FollowIncludeProperty> includeProperties, Exception exception)
        : base(FollowExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
