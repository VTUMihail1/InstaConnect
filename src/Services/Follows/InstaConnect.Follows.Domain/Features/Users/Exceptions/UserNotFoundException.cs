using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string id)
        : base(UserExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }
}
