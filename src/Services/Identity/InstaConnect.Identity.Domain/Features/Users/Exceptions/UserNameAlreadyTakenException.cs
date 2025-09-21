using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameAlreadyTakenException : BadRequestException
{
    public UserNameAlreadyTakenException(string name) : base(
        UserExceptionErrorMessages.GetNameAlreadyTakenMessage(name))
    {
    }

    public UserNameAlreadyTakenException(string name, Exception exception) : base(
        UserExceptionErrorMessages.GetNameAlreadyTakenMessage(name), exception)
    {
    }
}
