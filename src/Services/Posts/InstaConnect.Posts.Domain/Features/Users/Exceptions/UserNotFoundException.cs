using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string id) : base(UserExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }
}
