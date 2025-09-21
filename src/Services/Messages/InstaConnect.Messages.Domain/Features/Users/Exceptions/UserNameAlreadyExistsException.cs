using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
    public UserNameAlreadyExistsException(string name)
        : base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
    {
    }
}
