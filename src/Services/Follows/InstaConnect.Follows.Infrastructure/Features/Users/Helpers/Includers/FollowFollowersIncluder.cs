using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class FollowFollowersIncluder : IUserIncluder
{
    private readonly IFollowsContext _context;

    public FollowFollowersIncluder(IFollowsContext context)
    {
        _context = context;
    }

    public FollowsDestinationType DestinationType => FollowsDestinationType.User;

    public FollowsIncludeType IncludeType => FollowsIncludeType.Follower;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.Follows,
                p => p.Id,
                l => l.Id.FollowerId,
                p => p.FollowFollowers
            );
    }
}
