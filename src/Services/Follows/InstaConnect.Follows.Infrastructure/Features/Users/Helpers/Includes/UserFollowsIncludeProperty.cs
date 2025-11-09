using InstaConnect.Follows.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includes;

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
