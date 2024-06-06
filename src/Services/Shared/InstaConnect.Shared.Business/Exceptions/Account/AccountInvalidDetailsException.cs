using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.Account;

public class AccountInvalidDetailsException : BadRequestException
{
    private const string ERROR_MESSAGE = "Invalid user details";

    public AccountInvalidDetailsException() : base(ERROR_MESSAGE)
    {
    }

    public AccountInvalidDetailsException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
