using InstaConnect.Shared.Business.Exceptions.Base;

namespace InstaConnect.Shared.Business.Exceptions.User;

public class UserNotFoundException : NotFoundException
{
    private const string ERROR_MESSAGE = "User not found";

    public UserNotFoundException() : base(ERROR_MESSAGE)
    {
    }
}
