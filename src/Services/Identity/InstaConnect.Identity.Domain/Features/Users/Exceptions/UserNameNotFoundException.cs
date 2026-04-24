using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameNotFoundException : NotFoundException
{
    public UserNameNotFoundException(Name name)
        : base(UserExceptionErrorMessages.GetNameNotFoundMessage(name))
    {
    }
}
