using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.User;

public class UserEmailNotConfirmedException : BadRequestException
{
    private const string ERROR_MESSAGE = "Email needs to be confirmed";

    public UserEmailNotConfirmedException() : base(ERROR_MESSAGE)
    {
    }

    public UserEmailNotConfirmedException(Exception exception) : base(ERROR_MESSAGE, exception)
    {
    }
}
