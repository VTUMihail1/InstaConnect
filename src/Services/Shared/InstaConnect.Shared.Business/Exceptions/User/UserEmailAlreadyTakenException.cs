using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.User;

public class UserEmailAlreadyTakenException : BadRequestException
{
    private const string ERROR_MESSAGE = "Email already taken";

    public UserEmailAlreadyTakenException() : base(ERROR_MESSAGE)
    {
    }

    public UserEmailAlreadyTakenException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
