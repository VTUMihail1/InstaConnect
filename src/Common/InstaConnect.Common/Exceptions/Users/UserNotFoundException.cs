namespace InstaConnect.Shared.Common.Exceptions.Users;

public class UserNotFoundException : NotFoundException
{
    private const string ErrorMessage = "User not found";

    public UserNotFoundException() : base(ErrorMessage)
    {
    }
}
