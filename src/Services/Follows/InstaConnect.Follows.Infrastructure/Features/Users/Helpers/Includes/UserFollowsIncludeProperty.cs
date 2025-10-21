using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class UserFollowsIncludeProperty : IUserIncludeProperty
{
    private readonly IFollowsContext _followsContext;

    public UserFollowsIncludeProperty(IFollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.Follows;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, Follow, User>(
                _followsContext.Follows,
                p => p.Id,
                l => l.FollowerId,
                p => p.Follows
            );
    }
}
