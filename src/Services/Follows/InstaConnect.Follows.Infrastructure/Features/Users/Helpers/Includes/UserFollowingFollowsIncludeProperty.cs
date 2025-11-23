using InstaConnect.Follows.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includes;

public class UserFollowingFollowsIncludeProperty : IUserIncludeProperty
{
    private readonly IFollowsContext _followsContext;

    public UserFollowingFollowsIncludeProperty(IFollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.FollowerFollows;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .Lookup<User, Follow, User>(
                _followsContext.Follows,
                p => p.Id,
                l => l.Id.FollowingId,
                p => p.FollowingFollows
            );
    }
}
