using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailNotConfirmedException : BadRequestException
{
    public UserEmailNotConfirmedException(string email) : base(
        UserExceptionErrorMessages.GetEmailNotConfirmedMessage(email))
    {
    }

    public UserEmailNotConfirmedException(string email, Exception exception) : base(
        UserExceptionErrorMessages.GetEmailNotConfirmedMessage(email), exception)
    {
    }
}
