using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.User;

public class UserInvalidDetailsException : BadRequestException
{
    private const string ERROR_MESSAGE = "Invalid user details";

    public UserInvalidDetailsException() : base(ERROR_MESSAGE)
    {
    }

    public UserInvalidDetailsException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
