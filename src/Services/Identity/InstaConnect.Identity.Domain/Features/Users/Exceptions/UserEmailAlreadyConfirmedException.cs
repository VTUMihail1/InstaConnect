using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyConfirmedException : BadRequestException
{
    public UserEmailAlreadyConfirmedException(string email) : base(
        UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(email))
    {
    }

    public UserEmailAlreadyConfirmedException(string email, Exception exception) : base(
        UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(email), exception)
    {
    }
}
