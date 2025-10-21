using InstaConnect.UserClaims.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.UserClaims.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeQueryBuilderFactory : IUserClaimIncludeQueryBuilderFactory
{
    public UserClaimIncludeQueryBuilder Create()
    {
        return new UserClaimIncludeQueryBuilder([]);
    }
}
