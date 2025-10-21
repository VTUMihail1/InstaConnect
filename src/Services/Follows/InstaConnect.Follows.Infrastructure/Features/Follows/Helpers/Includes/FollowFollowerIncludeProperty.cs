using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
