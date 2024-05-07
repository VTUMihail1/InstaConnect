using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account;

public class AccountUnauthorizedException : UnauthorizedException
{
    private const string ERROR_MESSAGE = "Current user is not authenticated";

    public AccountUnauthorizedException() : base(ERROR_MESSAGE)
    {
    }

    public AccountUnauthorizedException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
