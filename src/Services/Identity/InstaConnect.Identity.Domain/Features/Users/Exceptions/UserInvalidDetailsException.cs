using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserInvalidDetailsException : BadRequestException
{
    private const string ErrorMessage = "Invalid user details";

    public UserInvalidDetailsException() : base(ErrorMessage)
    {
    }

    public UserInvalidDetailsException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
