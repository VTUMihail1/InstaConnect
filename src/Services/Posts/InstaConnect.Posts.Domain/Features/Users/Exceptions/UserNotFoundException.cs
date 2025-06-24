using InstaConnect.Common.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
    private const string ErrorMessage = "User not found";

    public UserNotFoundException() : base(ErrorMessage)
    {
    }
}
