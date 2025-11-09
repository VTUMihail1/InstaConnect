using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserIncludePropertiesNotSupportedException : BadRequestException
{
    public UserIncludePropertiesNotSupportedException(ICollection<UserIncludeProperty> includeProperties)
        : base(UserExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public UserIncludePropertiesNotSupportedException(ICollection<UserIncludeProperty> includeProperties, Exception exception)
        : base(UserExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
