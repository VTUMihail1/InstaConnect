using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
    public UserNameAlreadyExistsException(string name)
        : base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
    {
    }
}
