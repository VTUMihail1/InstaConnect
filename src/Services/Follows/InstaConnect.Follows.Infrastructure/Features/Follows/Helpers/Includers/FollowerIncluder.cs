using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowerIncluder : IFollowIncluder
{
    private readonly IFollowsContext _context;

    public FollowerIncluder(IFollowsContext context)
    {
        _context = context;
    }

    public FollowsDestinationType DestinationType => FollowsDestinationType.Follow;

    public FollowsIncludeType IncludeType => FollowsIncludeType.Follower;

    public IAggregateFluent<Follow> Include(IAggregateFluent<Follow> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.FollowerId,
                u => u.Id,
                p => p.Follower!
            );
    }
}
