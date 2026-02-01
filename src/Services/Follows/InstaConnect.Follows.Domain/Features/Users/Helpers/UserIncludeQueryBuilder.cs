namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilder
{
    private readonly ICollection<UserIncludeProperty> _includeProperties;

    internal UserIncludeQueryBuilder(ICollection<UserIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserIncludeQueryBuilder WithFollows()
    {
        _includeProperties.Add(UserIncludeProperty.FollowerFollows);

        return this;
    }

    public CommonInclude<UserIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
