using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.User;

public class UserUnauthorizedException : UnauthorizedException
{
    private const string ERROR_MESSAGE = "Current user is not authenticated";

    public UserUnauthorizedException() : base(ERROR_MESSAGE)
    {
    }

    public UserUnauthorizedException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
