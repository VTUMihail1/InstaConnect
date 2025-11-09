using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
    public UserNameAlreadyExistsException(string name)
        : base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
    {
    }
}
