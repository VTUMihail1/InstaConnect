using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
    public UserEmailAlreadyExistsException(string email)
        : base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
    {
    }
}
