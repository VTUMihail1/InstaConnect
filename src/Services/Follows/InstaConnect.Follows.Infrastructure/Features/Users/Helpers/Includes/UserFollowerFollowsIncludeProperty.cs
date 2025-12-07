using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includes;

public class UserFollowerFollowsIncludeProperty : IUserIncludeProperty
{
    private readonly IFollowsContext _followsContext;

    public UserFollowerFollowsIncludeProperty(IFollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.FollowerFollows;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _followsContext.Follows,
                p => p.Id,
                l => l.Id.FollowerId,
                p => p.FollowerFollows
            );
    }
}
