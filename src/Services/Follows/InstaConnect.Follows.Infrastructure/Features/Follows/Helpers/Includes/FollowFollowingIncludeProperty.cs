using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

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
            .Lookup<Follow, User, Follow>(
                _followsContext.Users,
                p => p.FollowingId,
                u => u.Id,
                p => p.Following
            );
    }
}
