namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeBuilder
{
    private readonly ICollection<UserClaimIncludeProperty> _includeProperties;

    internal UserClaimIncludeBuilder(ICollection<UserClaimIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserClaimInclude Build()
    {
        return new(_includeProperties);
    }
}
