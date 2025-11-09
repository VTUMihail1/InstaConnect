using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
    public UserEmailAlreadyExistsException(string email)
        : base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
    {
    }
}
