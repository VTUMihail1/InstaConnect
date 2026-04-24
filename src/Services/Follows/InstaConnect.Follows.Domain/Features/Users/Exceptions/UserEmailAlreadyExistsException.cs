using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
    public UserEmailAlreadyExistsException(Email email)
        : base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
    {
    }
}
