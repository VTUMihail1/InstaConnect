using InstaConnect.Shared.Common.Exceptions.Base;

namespace InstaConnect.Shared.Common.Exceptions.User;

public class UserNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "User not found";

    public UserNotFoundException() : base(ERROR_MESSAGE)
    {
    }
}
