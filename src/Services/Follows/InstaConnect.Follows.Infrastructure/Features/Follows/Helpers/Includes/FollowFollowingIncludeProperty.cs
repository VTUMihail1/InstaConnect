using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includes;

public class FollowFollowingIncludeProperty : IFollowIncludeProperty
{
    private readonly IFollowsContext _followsContext;

    public FollowFollowingIncludeProperty(IFollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public FollowIncludeProperty IncludeProperty => FollowIncludeProperty.Following;

    public IAggregateFluent<Follow> Include(IAggregateFluent<Follow> pipeline)
    {
        return pipeline
            .IncludeOne(
                _followsContext.Users,
                p => p.Id.FollowingId,
                u => u.Id,
                p => p.Following!
            );
    }
}
