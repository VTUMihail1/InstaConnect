namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

public class UserIncludeBuilderFactory : IUserIncludeBuilderFactory
{
    public UserIncludeBuilder Create()
    {
        return new UserIncludeBuilder([]);
    }
}
