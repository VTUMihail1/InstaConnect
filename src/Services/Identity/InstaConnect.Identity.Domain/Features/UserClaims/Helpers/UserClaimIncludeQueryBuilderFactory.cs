namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeQueryBuilderFactory : IUserClaimIncludeQueryBuilderFactory
{
    public UserClaimIncludeQueryBuilder Create()
    {
        return new UserClaimIncludeQueryBuilder([]);
    }
}
