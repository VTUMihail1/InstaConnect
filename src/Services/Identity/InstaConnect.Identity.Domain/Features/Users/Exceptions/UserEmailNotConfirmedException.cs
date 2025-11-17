using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailNotConfirmedException : BadRequestException
{
    public UserEmailNotConfirmedException(Email email) : base(
        UserExceptionErrorMessages.GetEmailNotConfirmedMessage(email))
    {
    }

    public UserEmailNotConfirmedException(Email email, Exception exception) : base(
        UserExceptionErrorMessages.GetEmailNotConfirmedMessage(email), exception)
    {
    }
}
