using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserInvalidDetailsException : BadRequestException
{
    public UserInvalidDetailsException(string name) : base(
        UserExceptionErrorMessages.GetInvalidDetailsMessage(name))
    {
    }

    public UserInvalidDetailsException(string name, Exception exception) : base(
        UserExceptionErrorMessages.GetInvalidDetailsMessage(name), exception)
    {
    }
}
