using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account;

public class AccountForbiddenException : ForbiddenException
{
    private const string ERROR_MESSAGE = "Account is forbidden";

    public AccountForbiddenException() : base(ERROR_MESSAGE)
    {
    }

    public AccountForbiddenException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
