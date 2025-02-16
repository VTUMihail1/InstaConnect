using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.Users;

public class UserForbiddenException : ForbiddenException
{
    private const string ErrorMessage = "User access is forbidden";

    public UserForbiddenException() : base(ErrorMessage)
    {
    }

    public UserForbiddenException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
