using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.User;

public class UserForbiddenException : ForbiddenException
{
    private const string ERROR_MESSAGE = "User access is forbidden";

    public UserForbiddenException() : base(ERROR_MESSAGE)
    {
    }

    public UserForbiddenException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
