using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailNotFoundException : NotFoundException
{
    public UserEmailNotFoundException(string email)
        : base(UserExceptionErrorMessages.GetEmailNotFoundMessage(email))
    {
    }
}
