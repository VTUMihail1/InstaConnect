using InstaConnect.Follows.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includes;

public class FollowFollowerIncludeProperty : IFollowIncludeProperty
{
    private readonly IFollowsContext _followsContext;

    public FollowFollowerIncludeProperty(IFollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public FollowIncludeProperty IncludeProperty => FollowIncludeProperty.Follower;

    public IAggregateFluent<Follow> Include(IAggregateFluent<Follow> pipeline)
    {
        return pipeline
            .Lookup<Follow, User, Follow>(
                _followsContext.Users,
                p => p.FollowerId,
                u => u.Id,
                p => p.Follower
            );
    }
}
