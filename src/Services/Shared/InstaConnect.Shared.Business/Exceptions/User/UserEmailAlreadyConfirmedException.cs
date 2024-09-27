using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.User;

public class UserEmailAlreadyConfirmedException : BadRequestException
{
    private const string ERROR_MESSAGE = "Email already confirmed";

    public UserEmailAlreadyConfirmedException() : base(ERROR_MESSAGE)
    {
    }

    public UserEmailAlreadyConfirmedException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
