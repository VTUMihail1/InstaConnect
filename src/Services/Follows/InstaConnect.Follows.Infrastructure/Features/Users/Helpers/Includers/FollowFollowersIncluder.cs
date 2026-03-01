using InstaConnect.Follows.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class FollowFollowersIncluder : IUserIncluder
{
    private readonly IFollowsContext _context;

    public FollowFollowersIncluder(IFollowsContext context)
    {
        _context = context;
    }

    public FollowsDestinationType DestinationType => FollowsDestinationType.Users;

    public FollowsIncludeType IncludeType => FollowsIncludeType.Followers;

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
