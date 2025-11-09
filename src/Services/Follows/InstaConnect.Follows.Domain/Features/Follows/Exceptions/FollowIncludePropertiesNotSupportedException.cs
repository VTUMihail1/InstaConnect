using InstaConnect.Common.Domain.Exceptions;

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
