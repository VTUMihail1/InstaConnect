using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailNotConfirmedException : BadRequestException
{
    private const string ErrorMessage = "Email needs to be confirmed";

    public UserEmailNotConfirmedException() : base(ErrorMessage)
    {
    }

    public UserEmailNotConfirmedException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
