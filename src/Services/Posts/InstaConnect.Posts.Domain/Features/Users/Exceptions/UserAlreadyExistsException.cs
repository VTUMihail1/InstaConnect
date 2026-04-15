using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
    public UserAlreadyExistsException(UserId id)
        : base(UserExceptionErrorMessages.GetAlreadyExistsMessage(id))
    {
    }
}
