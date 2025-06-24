using InstaConnect.Common.Exceptions;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyConfirmedException : BadRequestException
{
    private const string ErrorMessage = "Email already confirmed";

    public UserEmailAlreadyConfirmedException() : base(ErrorMessage)
    {
    }

    public UserEmailAlreadyConfirmedException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
