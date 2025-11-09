namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeQueryBuilder
{
    private readonly ICollection<UserClaimIncludeProperty> _includeProperties;

    internal UserClaimIncludeQueryBuilder(ICollection<UserClaimIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserClaimIncludeQuery Build()
    {
        return new UserClaimIncludeQuery(_includeProperties);
    }
}
