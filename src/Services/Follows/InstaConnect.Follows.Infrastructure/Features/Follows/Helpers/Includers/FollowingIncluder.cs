using InstaConnect.Follows.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowingIncluder : IFollowIncluder
{
    private readonly IFollowsContext _context;

    public FollowingIncluder(IFollowsContext context)
    {
        _context = context;
    }

    public FollowsDestinationType DestinationType => FollowsDestinationType.Follows;

    public FollowsIncludeType IncludeType => FollowsIncludeType.Followings;

    public IAggregateFluent<Follow> Include(IAggregateFluent<Follow> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.FollowingId,
                u => u.Id,
                p => p.Following!
            );
    }
}
