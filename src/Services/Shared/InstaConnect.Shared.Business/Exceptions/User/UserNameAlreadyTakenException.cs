using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.User;

public class UserNameAlreadyTakenException : BadRequestException
{
    private const string ERROR_MESSAGE = "Username already taken";

    public UserNameAlreadyTakenException() : base(ERROR_MESSAGE)
    {
    }

    public UserNameAlreadyTakenException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
