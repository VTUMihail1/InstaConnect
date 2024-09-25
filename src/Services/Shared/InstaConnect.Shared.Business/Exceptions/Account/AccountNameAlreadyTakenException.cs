using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account;

public class AccountNameAlreadyTakenException : BadRequestException
{
    private const string ERROR_MESSAGE = "Username already taken";

    public AccountNameAlreadyTakenException() : base(ERROR_MESSAGE)
    {
    }

    public AccountNameAlreadyTakenException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
