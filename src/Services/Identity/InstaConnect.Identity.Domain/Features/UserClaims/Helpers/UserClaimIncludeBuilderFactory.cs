namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeBuilderFactory : IUserClaimIncludeBuilderFactory
{
    public UserClaimIncludeBuilder Create()
    {
        return new UserClaimIncludeBuilder([]);
    }
}
