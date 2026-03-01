using InstaConnect.Identity.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includers;

internal class UserIncluder : IRefreshTokenIncluder
{
    private readonly IIdentityContext _context;

    public UserIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.RefreshTokens;

    public IdentityIncludeType IncludeType => IdentityIncludeType.Users;

    public IAggregateFluent<RefreshToken> Include(IAggregateFluent<RefreshToken> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.Id,
                l => l.Id,
                p => p.User!
            );
    }
}
