using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Domain.Features.Users.Exceptions;

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
