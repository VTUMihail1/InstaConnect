using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyTakenException : BadRequestException
{
    private const string ErrorMessage = "Email already taken";

    public UserEmailAlreadyTakenException() : base(ErrorMessage)
    {
    }

    public UserEmailAlreadyTakenException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
