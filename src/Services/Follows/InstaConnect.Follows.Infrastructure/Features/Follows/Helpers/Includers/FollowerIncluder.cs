using InstaConnect.Follows.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowerIncluder : IFollowIncluder
{
    private readonly IFollowsContext _context;

    public FollowerIncluder(IFollowsContext context)
    {
        _context = context;
    }

    public FollowsDestinationType DestinationType => FollowsDestinationType.Follows;

    public FollowsIncludeType IncludeType => FollowsIncludeType.Followers;

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
