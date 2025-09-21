using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
    public UserAlreadyExistsException(string id)
        : base(UserExceptionErrorMessages.GetAlreadyExistsMessage(id))
    {
    }
}
