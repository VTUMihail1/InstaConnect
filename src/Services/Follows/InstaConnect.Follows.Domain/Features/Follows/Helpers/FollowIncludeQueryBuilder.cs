using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowIncludeQueryBuilder
{
    private readonly ICollection<FollowIncludeProperty> _includeProperties;

    internal FollowIncludeQueryBuilder(ICollection<FollowIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public FollowIncludeQueryBuilder WithFollower()
    {
        _includeProperties.Add(FollowIncludeProperty.Follower);

        return this;
    }

    public FollowIncludeQueryBuilder WithFollowing()
    {
        _includeProperties.Add(FollowIncludeProperty.Following);

        return this;
    }

    public CommonIncludeQuery<FollowIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
