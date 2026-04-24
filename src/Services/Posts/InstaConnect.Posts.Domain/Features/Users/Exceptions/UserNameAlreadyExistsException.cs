using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
    public UserNameAlreadyExistsException(Name name)
        : base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
    {
    }
}
