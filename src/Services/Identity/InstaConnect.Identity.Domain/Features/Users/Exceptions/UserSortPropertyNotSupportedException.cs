using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
