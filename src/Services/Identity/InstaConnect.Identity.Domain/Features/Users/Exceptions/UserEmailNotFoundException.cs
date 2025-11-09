using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailNotFoundException : NotFoundException
{
    public UserEmailNotFoundException(string email)
        : base(UserExceptionErrorMessages.GetEmailNotFoundMessage(email))
    {
    }
}
