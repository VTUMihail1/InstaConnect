using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserSortPropertyNotSupportedException : BadRequestException
{
    public UserSortPropertyNotSupportedException(UserSortProperty sortProperty)
        : base(UserExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public UserSortPropertyNotSupportedException(UserSortProperty sortProperty, Exception exception)
        : base(UserExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
