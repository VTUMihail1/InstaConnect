using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameAlreadyTakenException : BadRequestException
{
    private const string ErrorMessage = "Username already taken";

    public UserNameAlreadyTakenException() : base(ErrorMessage)
    {
    }

    public UserNameAlreadyTakenException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
