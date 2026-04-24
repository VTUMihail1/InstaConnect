using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class FollowFollowingsIncluder : IUserIncluder
{
    private readonly IFollowsContext _context;

    public FollowFollowingsIncluder(IFollowsContext context)
    {
        _context = context;
    }

    public FollowsDestinationType DestinationType => FollowsDestinationType.User;

    public FollowsIncludeType IncludeType => FollowsIncludeType.Following;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.Follows,
                p => p.Id,
                l => l.Id.FollowingId,
                p => p.FollowFollowings
            );
    }
}
