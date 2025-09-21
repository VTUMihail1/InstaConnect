using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyTakenException : BadRequestException
{
    public UserEmailAlreadyTakenException(string email) : base(
        UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(email))
    {
    }

    public UserEmailAlreadyTakenException(string email, Exception exception) : base(
        UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(email), exception)
    {
    }
}
